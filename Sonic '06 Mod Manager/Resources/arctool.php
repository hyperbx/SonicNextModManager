<?php
$create=false;
$simulate=false;
$extract=false;
$compressionlevel=0;
$overwrite=false;
$arranged=true;
$inputdir="./";
$fs=-1;
$filename="";

for($i=1;$i<$argc;$i++)
{
	switch($argv[$i]) {
		case "-d":
			$extract=true;
			break;
		case "-s":
			$simulate=true;
			break;
		case "-c":
			$create=true;
			break;
		case "-f":
			$overwrite=true;
			break;
		case "-j":
			if($i!=$argc-1)
				$fs=$argv[$i+1];
			$i++;
			break;
		case "-i":
			if($i!=$argc-1)
				$inputdir=$argv[$i+1];
			$i++;
			break;
		default:
			$cmd=substr($argv[$i],0,2);
			$val=substr($argv[$i],2);
			if($cmd=="-a") $arranged=(($val == "1") ? true:false);
			else if($cmd=="-c") $compressionlevel=$val;
			else $filename=$argv[$i];
			break;
	}
}

if($filename=="")
{
	die($argv[0]." [options] [filename]\n
Possible options:
-d: Deflate/Extract (standard if file does already exist)
-s: List files (simulate extraction)
-c: Create ARC file (standard if file does not already exist)
-l#:Compression level (# ranges from 0 to 9, 9 being default, 0 meaning no compression at all) (only for creation)
-a#:Write 32-byte-arranged ARC files (#1 for true, true is default) (only for creation)
-f: Force overwriting of old ARC file
-i: Input directory (only for creation)
-j [filesize/filename]: Fill file with junk data (only for creation)
   If a numeric value is given: the final file will be at least as large as the given value
   If a filename is given, the filesize of the filename given will be used for final size!
   
ARC file format/Unpacker: written by xose
Packer: written by Link");
}

if(!($create || $extract || $simulate))
{
	if(file_exists($filename))
         	$extract=true;
         else
         	$create=true;
}

if($simulate || $extract)
{
	if(!file_exists($filename))
         	die("File not found");
    $doit=!$simulate;

    include("unarc.php");
    die;
}

if($create)
{
	if(file_exists($filename) && !$overwrite)
		die("File already exists... append -f to overwrite");
	else if(file_exists($filename))
		unlink($filename);

 	if(!is_numeric($compressionlevel) || $compressionlevel<0 || $compressionlevel>9)
		die("Invalid compression level set!");

	if(!is_numeric($fs)) {
		if(file_exists($fs))
			$fs=filesize($fs);
			else
				die("File size value invalid - reference file not found!");
	}

	if(!file_exists($inputdir)) {
		die("Input directory not found");
	}

	$inputdir=str_replace("\\","/",$inputdir);
	while(substr($inputdir,-1,1) == "/") $inputdir=substr($inputdir,0,-1);

	include("arcc.php");
	die;
}
?>