# Question One

Find score on dart board give coordinates (x,y)

## How to run code

This assignment has been done using a PHP script.

### Requirements

- PHP server (Apache | Nginx)
- Alternative is to use an online IDE [Writephponline](http://www.writephponline.com) 

## Code

```php

<?php

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

```