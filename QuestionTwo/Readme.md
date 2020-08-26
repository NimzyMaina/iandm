# Question Two

Find most valuable items 

## How to run code

This assignment has been done using a PHP script.

### Requirements

- PHP server (Apache | Nginx)
- Alternative is to use an online IDE [Writephponline](http://www.writephponline.com) 

## Code

```php
<?php

$inputs = json_decode('[ { "weight": 5, "value": 10 }, { "weight": 4, "value": 40 }, { "weight": 6, "value": 30 }, { "weight": 4, "value": 50 } ]',true);

// get value per weight (worth)
$inputs = array_map(function ($input){
    $input['worth'] = $input['value']/$input['weight'];
    return $input;
},$inputs);
// sort from highest worth to lowest worth
usort($inputs, function ($a, $b){
    return $a['worth'] < $b['worth'];
});
// Make sure Knapsack has weight of less than 10
$weight = 0;
$inputs = array_filter($inputs, function ($input) use (&$weight) {
    $weight += $input['weight'];
    return $weight <= 10 ;
});

echo json_encode($inputs);

```


## Output from code

```json
[
    {
        "weight": 4,
        "value": 50,
        "worth": 12.5
    },
    {
        "weight": 4,
        "value": 40,
        "worth": 10
    }
]
```