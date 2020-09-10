# Calculator

Simple calculator that uses stack of size 5 to store unsigned 10 bit integers. Can add or subtract.

Examples:
```
push 5
push 10
add
>> 15
push 20
sub
>> 5
```
Overflow or underflow is reduced modulo by 1024.
```
push 7
push 5
sub
>> 1022
```

