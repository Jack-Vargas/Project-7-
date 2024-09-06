VAR EpicBoolTime = true
VAR AnimeYouveWatched = 9
VAR switchExample = 1

VAR boolA = true
VAR boolB = true
VAR boolC = false

{EpicBoolTime: this is writen if its true | this is writen if false}

{AnimeYouveWatched < 8: 
if over 8 
- else:
if Under 8
}

{switchExample:
- 0: no
- 1: yes
- else: krinoo
}

* { boolA } [hi]

* { boolB } [bye]

* { boolC } [NO] // this one wont show up since bool c is false


{RANDOM(1,5)} // makes a random number from 1-5

{TURNS()} // the number of lines youve done i think?