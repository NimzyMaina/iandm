<?php

/*
 * Outside Dart radius > 10 | score = 0
 * Outer Circle radius = 10 | score = 1
 * Middle Circle radius = 5 | score = 5
 * Inner Circle radius = 1  | score = 10
 */
function score($x, $y)
{
    $score = 0;
    // Pythogoras' Theorem
    $distance = sqrt(pow($x,2) + pow($y,2));
    if($distance <= 1){
        $score = 10;
    }
    elseif ($distance > 1 && $distance <= 5){
        $score = 5;
    }
    elseif ($distance > 5 && $distance <= 10)
    {
        $score = 1;
    }

    return $score;
}

$x_cord = 0;
$y_cord = 10;

$outcome = score($x_cord, $y_cord);

echo "Your score is $outcome";



