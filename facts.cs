/*
Audio Listener is a coponent for Main Camera
Audio Source will be on player
Audacity - OggVorbis File (.OGG) or mp3 for unity
Play on Awake - as the game starts
Loop - to play it on Loop
Edit>Project Settings>Audio>System Sample Rate = 1.if its 0 u wont hear the sound
Start Update collision is a part of monobehaviour
StartUnity engine is a namespace for monobehaviour
File>Build Settings>add scenes or drag them from scenes folder.starts at 0
using Invoke() allows us to call a method so it executes a delay of x seconds
Syntax : Invoke("MethodName",delayInSeconds);

particle system is a game object component
theres an emitter
Pink particles are default when particle is not provided
we use Modules for controlling behaviour
make sure looping and play on awake is turned off in particle system

oscillating platform
how to move object using code backwards and forwards
we need a starting position vector3 (x, y,z) and movement vector(x1,y1,z1) where moving .add x+x1
movement factor is needed to go back and forth (0 to 1)
offset = movement vector * movement factor
Mathf.sin() is used for movement here

two floats can vary by a tiny amount
its unoredictable to use == with floats
always specify the acceptable difference
the smallest float is Mathf.Epsilon
always compare to this rather than zero
for example 
if(period <= Math.Epsilon){return;}












*/