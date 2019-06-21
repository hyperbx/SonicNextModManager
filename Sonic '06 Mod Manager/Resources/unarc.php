<?php

// Dirty way of extracting Xbox 360 .ARC files
// Written by xose <xosemp@gmail.com>

// See arcformat.txt


/*if (!version_compare(phpversion(), "4.0.0", ">="))
	die("PHP 4 required");

if (!function_exists('gzuncompress'))
	die("PHP zlib support required");


if ($argc == 2 && $argv[1] != "-s") //extract
{
	if (!file_exists($argv[1]))
		die("File {$argv[1]} does not exist");

         $outdir = substr($argv[1], 0, -4);
         $fp = fopen($argv[1], 'rb');
	$doit = true;
         $repack = false;
}
elseif ($argc == 3 && $argv[1] == "-s")
{
	if (!file_exists($argv[2]))
		die("File {$argv[2]} does not exist");

	$fp = fopen($argv[2], 'rb');
	$outdir = substr($argv[2], 0, -4);
	$doit = false;
         $extract = false;
}
else
	die("Usage: {$argv[0]} [-s] file.arc\n\n-s : simulate only (do not extract)\n");*/

$fp = fopen($filename, 'rb');
$outdir = substr($filename, 0, -4);

fseek($fp, 4*10);

$dt=fread($fp, 4);

$filecount = unpack('N', $dt);
$filecount = $filecount[1];

fseek($fp, 4*2);
$filedatalen = unpack('N', fread($fp, 4));
$filedatalen = $filedatalen[1] - (16*$filecount);

echo "Extracting {$filecount} files...\n\n";

fseek($fp, 4*8);

for ($i = 0; $i < 4*$filecount; $i++)
{
	$data = unpack('N', fread($fp, 4));

	$nums[] = $data[1];
}

$j = 1;
foreach ($nums as $data)
{
	$b[] = $data;
	$j++;

	if ($j == 5)
	{
		$d[] = $b;
		$b = array();
		$j = 1;
	}
}

//print_r($d);
//die;

$files = fread($fp, $filedatalen);

for ($i = 0; $i < $filedatalen; $i++)
{
	if ($files{$i} != chr(0))
		$file .= $files{$i};
	else
	{
		$filearr[] = $file;
		$file = '';
	}
}

//print_r($filearr);
//die;

for ($i = 0; $i < $filecount; $i++)
{
	$info['name'] = $filearr[$i];

	$info['isdir'] = ($d[$i][0] >= 16777216 ? 'yes' : 'no');
	$info['namepos'] = ($info['isdir'] == 'yes' ? $d[$i][0] - 16777216 : $d[$i][0]);

	$info['start'] = $d[$i][1];
	$info['length'] = $d[$i][2];
	$info['unpacked'] = $d[$i][3];
    $info['dataset'] = 4*8+$i*16; //Added: this is the part where this file is represented in the ARC header

	$fileinfo[] = $info;
}

//print_r($fileinfo);
//die;

function fcreate($output,$data)
{
	$fle=fopen($output,"wb");
    fwrite($fle,$data);
    fclose($fle);
}


function extractfile($output, $start, $length, $ulength)
{
	global $fp,$outdir,$outdir;

    fseek($fp, $start);
	$data = fread($fp, $length);
    echo 'Extracting '.substr($output,strlen($outdir)+1).'...';
    if ($ulength > 0)
        $data = gzuncompress($data, $ulength);
	echo " complete!\n";
 	//file_put_contents($output, $data);
    fcreate($output,$data);
}

function tree($in, $start, $cur, $base)
{
	global $fileinfo;
	global $doit;

	if ($doit)
          @mkdir($base.$cur);

	$i = $start;
	while ($i < $in['length'])
	{
		if ($fileinfo[$i]['isdir'] == 'yes')
		{
			tree($fileinfo[$i], $i+1, $cur.'/'.$fileinfo[$i]['name'], $base);
			$i = $fileinfo[$i]['length'];
		}
		else
		{
			if ($doit) extractfile($base.$cur.'/'.$fileinfo[$i]['name'], $fileinfo[$i]['start'], $fileinfo[$i]['length'], $fileinfo[$i]['unpacked']);
			else echo $cur.'/'.$fileinfo[$i]['name']."\n";
			$i++;
		}
	}
}

tree($fileinfo[0], 1, "", $outdir);

fclose($fp);

echo "\nDone.";

?>