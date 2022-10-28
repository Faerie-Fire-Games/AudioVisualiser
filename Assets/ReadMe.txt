Jade Britzman s3920256

Github Repo: 

This is a very simple audio visualiser. It is supposed to abstractly resemble a vinyl record that pulses with the music. When the music hits a certain point a particle burst will occur and all the colours will change. Designed for use with this song https://open.spotify.com/track/46gSk82duJtX3TTA182ruG?si=637e2ebf8a2545ac (Works with anything though of course)

I believe for many people the LUnity audio visualiser wasn't working in the build. This is true for me also. I've included the build anyway just in case it works for some reason, but currently the editor version must be used.

This audio visualiser is exceptionally simple, for reasons that are outlined in my Canvas comment. Which if you didn't see then yeah you should check that out. It uses the LUnity Audio Vis package to take audio input from the computer and separates it into 19 "Bands" of frequency ranges. Each band is tied to one of the 19 circles. At runtime each circle is given a random colour. Each circle "pulses" in size in accordance with the volume of the frequency band being reported. When the 2nd band passes a certain threshold, a particle burst occurs behind the circles for emphasis. At this point, all of the colours, including the background colour is also randomly changed. This makes it a little more interesting to look at than simple pulsing.

Third Party Assets:
LUnity Audio Vis - https://github.com/lachlansleight/LunityAudioVis