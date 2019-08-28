<?php

//ARC packer
//written by Link

$checkdirectory;

$headpos=-1;
function PrepareHeader($fp,$fls,$fname="") { //writes incomplete header
	global $headpos;
	//if($fname=="") $fname=chr(0);
	if($fls["?isdir?"]) {
		fwrite($fp,pack('N',0x01000000+$headpos+1));
		fwrite($fp,pack('N',$fls["?parent?"]));
		fwrite($fp,pack('N',$fls["?count?"]));
		fwrite($fp,pack('N',0));
		$headpos+=1+strlen($fname);
		for($i=0;$i<count($fls["?filelist?"]);$i++)
			PrepareHeader($fp,$fls[$fls["?filelist?"][$i]],$fls["?filelist?"][$i]);
	} else {
		fwrite($fp,pack('N',$headpos+1));
		$headpos+=1+strlen($fname);
		fwrite($fp,pack('N',0));
		fwrite($fp,pack('N',0))	;
		fwrite($fp,pack('N',$fls["?filesize?"]));
	}
}

function FinalizeHeader($fp,$fls,$fname="",$folder="") { //writes final header (copy of function before just with final data)
//simply writes over the header again
	global $headpos;
	//if($fname=="") $fname=chr(0);
	if($fls["?isdir?"]) {
		fwrite($fp,pack('N',0x01000000+$headpos+1));
		fwrite($fp,pack('N',$fls["?parent?"]));
		fwrite($fp,pack('N',$fls["?count?"]));
		fwrite($fp,pack('N',0));
		$headpos+=1+strlen($fname);
		for($i=0;$i<count($fls["?filelist?"]);$i++)
			FinalizeHeader($fp,$fls[$fls["?filelist?"][$i]],$fls["?filelist?"][$i],$fls);
	} else if(!$fls["?virtual?"]) {
		fwrite($fp,pack('N',$headpos+1));
		$headpos+=1+strlen($fname);
		fwrite($fp,pack('N',$fls["?data?"]));
		fwrite($fp,pack('N',$fls["?compressed?"]));
		fwrite($fp,pack('N',$fls["?filesize?"]));
	} else {
		fwrite($fp,pack('N',$headpos+1));
		$headpos+=1+strlen($fname);
		fwrite($fp,pack('N',$folder[$fls["?realfile?"]]["?data?"]));
		fwrite($fp,pack('N',$folder[$fls["?realfile?"]]["?compressed?"]));
		fwrite($fp,pack('N',$fls["?filesize?"]));
	}
}


function WriteList($fp,$fls,$fname="") { //Writes the filelist
	fwrite($fp,$fname.chr(0));
		if($fls["?isdir?"])
			for($i=0;$i<count($fls["?filelist?"]);$i++)
				WriteList($fp,$fls[$fls["?filelist?"][$i]],$fls["?filelist?"][$i]);
}


function msort($a,$b) //sort files by filename, folders always first!
{
	global $checkdirectory;
	$dir=$checkdirectory;
	$a=strtoupper($a);
	$b=strtoupper($b);
	$array[0]=$a;
	$array[1]=$b;
	sort($array);

	if(is_dir($dir.$b) && !is_dir($dir.$a)) return -1;
	else if(is_dir($dir.$a) && !is_dir($dir.$b)) return 1;

	if($array[0]==$a) return -1;
	else return 1;
}

$fcount=1;

function file_ext($filename)
{
	return strtolower(str_replace(".", "", strrchr($filename, ".")));
}

function no_fname($filename)
{
	return substr($filename,0,(-1*strlen(file_ext($filename))-1));
}

function GenerateDirectoryList($dir="./",$parent=0) //Generate a directory list of the current directory
{
	global $checkdirectory,$fcount;
	$flist;
	if ($dh=opendir($dir)) {
		$checkdirectory=$dir;
		while (($file = readdir($dh)) !== false) {
			if($file!=".." && $file!=".")
				$flist[]=$file;
		}
		closedir($dh);
	}
	usort($flist,"msort");
	$res["?filelist?"]=$flist;
	$res["?isdir?"]=true;
	$res["?myid?"]=$fcount-1;
	$res["?parent?"]=$parent;

	$fstart=$fcount;

	for($i=0;$i<count($flist);$i++) {
		$fcount++;
		if(is_dir($dir.$flist[$i])) {
			$res[$flist[$i]]=GenerateDirectoryList($dir.$flist[$i]."/",$res["?myid?"]);
		}
		else if(is_file($dir.$flist[$i])) {
			if(file_ext($flist[$i])=="virt!") {
				$flist[$i]=no_fname($flist[$i]);
				$res["?filelist?"][$i]=$flist[$i];
				$res[$flist[$i]]["?virtual?"]=true;
				$vfile=file($dir.$flist[$i].".virt!");
				$res[$flist[$i]]["?realfile?"]=$vfile[0];
				$res[$flist[$i]]["?filesize?"]=filesize($dir.$vfile[0]);
			} else {
				$res[$flist[$i]]["?virtual?"]=false;
				$res[$flist[$i]]["?realfile?"]=$flist[$i];
				$res[$flist[$i]]["?filesize?"]=filesize($dir.$flist[$i]);
			}
			$res[$flist[$i]]["?isdir?"]=false;
		}
	}

	$res["?count?"]=$fcount;
	return $res;
}


//if ($argc != 2) {
//	die("Usage: php arc.php [output]");
//}

//echo file_ext("data.huhu.virt!")."\n".no_fname("data.huhu.virt!");
//die;


$tooldir=str_replace("\\","/",getcwd());
while(substr($tooldir,-1,1) == "/") $tooldir=substr($tooldir,0,-1);

if(!chdir($inputdir)) die("Failed changing directory");
$inputdir=str_replace("\\","/",getcwd());
while(substr($inputdir,-1,1) == "/") $inputdir=substr($inputdir,0,-1);

$files=GenerateDirectoryList();


if(!chdir($tooldir)) die("Failed changing directory");

$fp = fopen($filename, 'wb');

if(!chdir($inputdir)) die("Failed changing directory");


fwrite($fp,pack('N',0x55aa382d));
fwrite($fp,pack('N',0x20));

for($i=0;$i<8;$i++)
	fwrite($fp,chr(0));

fwrite($fp,pack('N',0xE4f91200));
fwrite($fp,pack('N',0x00000402));
fwrite($fp,pack('N',0));
fwrite($fp,pack('N',0));

function WriteFiles($fp,&$fls,$fname=".") {
	global $arranged,$compressionlevel;
	if($fls["?isdir?"]) {
		for($i=0;$i<count($fls["?filelist?"]);$i++)
		WriteFiles($fp,$fls[$fls["?filelist?"][$i]],$fname."/".$fls["?filelist?"][$i]);
	} else if(!$fls["?virtual?"]) {
		echo "Writing ".$fname."\n";
		if($arranged)
			while(ftell($fp)%32!=0)
				fwrite($fp,chr(0));
		$flup=fopen($fname,"rb");
		$dt=fread($flup,filesize($fname));
		fclose($flup);
		//if($compressionlevel == 0) //The final requires files to be compressed, even if it is compression level 0
		//{
			//$cmp=$dt;
			//$fls["?filesize?"]=0;
		//}
		//else
			$cmp=gzcompress($dt,$compressionlevel);
		$fls["?compressed?"]=strlen($cmp);
		$fls["?data?"]=ftell($fp);
		fwrite($fp,$cmp);
	}
}

PrepareHeader($fp,$files);
WriteList($fp,$files);

$filelistlength=ftell($fp)-0x20;

if($arranged)
	$filelistbegin=(floor($filelistlength/32)+1)*32+0x20;
else
	$filelistbegin=ftell($fp)+1; //1 byte for security reasons

while(ftell($fp)<$filelistbegin)
 fwrite($fp,chr(0));

WriteFiles($fp,$files);

fseek($fp,8);
fwrite($fp,pack('N',$filelistlength));
fwrite($fp,pack('N',$filelistbegin));

fseek($fp,0x20);

$headpos=-1;
FinalizeHeader($fp,$files);

fseek($fp,0,SEEK_END);
while(ftell($fp)<$fs)
	fwrite($fp,chr(0));

fclose($fp);

chdir($tooldir);

echo "\nDone.";
?>