<?php 

    //echo "Hello world!" . PHP_EOL; 
    //echo $_GET['score'] . PHP_EOL;


    //Creating array with scores
    $a=array();
    $bestScores=array();


    if(file_exists("scores.txt")) 
    {
        file_put_contents("scores.txt", (int)$_GET['score'] . PHP_EOL, FILE_APPEND);

        $handle = fopen("scores.txt", "r");
        if ($handle) 
        {
            while (($line = fgets($handle)) !== false) 
            {
                //echo $line;
                array_push($a, (int)$line);
            }
            fclose($handle);
        } 
        else 
        {
            echo "Error opening the scores!";
        } 

        

        rsort($a);

        //We only add the 8 best scores from the file
        foreach($a as $key=>$value) 
        {
            if($key+1 < 9) 
            {
                array_push($bestScores, $value);
            }
        }


        $fp = fopen("scores.txt","wb");
        foreach($bestScores as $value) 
        {
            file_put_contents("scores.txt", $value . PHP_EOL, FILE_APPEND);
        }
        fclose($fp);
        
    }
    else 
    { //if file doesnt exist we create it with the first score
        $content = $_GET['score'] . PHP_EOL;
        $fp = fopen("scores.txt","wb");
        fwrite($fp,$content);
        fclose($fp);
    }
    
    
    
    
    //Looping and getting the values inside the array
    foreach($bestScores as $key=>$value) {
        echo $key+1,"o lugar     ", $value, " metros" . PHP_EOL;
    }

?>	