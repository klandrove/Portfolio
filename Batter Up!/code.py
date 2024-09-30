import board
import digitalio
import time
import neopixel
import pwmio
import random

from adafruit_motor import servo

try:
    from audiocore import WaveFile
except ImportError:
    from audioio import WaveFile

try:
    from audioio import AudioOut
except ImportError:
    try:
        from audiopwmio import PWMAudioOut as AudioOut
    except ImportError:
        pass  # not always supported by every board!

# Enable the speaker
spkrenable = digitalio.DigitalInOut(board.SPEAKER_ENABLE)
spkrenable.direction = digitalio.Direction.OUTPUT
spkrenable.value = True

#from adafruit_circuitplayground import cp

slide_switch = digitalio.DigitalInOut(board.SLIDE_SWITCH)
slide_switch.direction = digitalio.Direction.INPUT
slide_switch.pull = digitalio.Pull.UP

# BUTTON_A is an reference to the 2 buttons on the Circuit Python Express
switch = digitalio.DigitalInOut(board.A6)
switch.direction = digitalio.Direction.INPUT

# pull controls the electrical behavoir of the pin
# The standard Pull.DOWN as electricity flows through the pin, switch.value = False(LOW), When the button is pressed, switch.value = True(HIGH)
switch.pull = digitalio.Pull.DOWN

pixels = neopixel.NeoPixel(board.A1, 16, brightness=0.3, auto_write=False)
pwm = pwmio.PWMOut(board.A2, duty_cycle=2 ** 15, frequency=50)
my_servo = servo.Servo(pwm)

WHITE = (255, 240, 140)
OFF = (0, 0, 0)

mode = 0
wasPressed = False

wave_file = open("charge.wav", "rb")
charge = WaveFile(wave_file)
audio = AudioOut(board.SPEAKER)
wasPlayed = False

while True:
  if(slide_switch.value == True):
    print("Slide True: Electricity is flowing through the circuit")
    if wasPlayed == False:
        audio.play(charge)
        wasPlayed=True
        print(wasPlayed)
    pixels.fill(WHITE)
    pixels.show()
    if switch.value == True:
        wasPressed = True # Keeps track that the button is pressed
    else:
        # This is the state when the button is de-pressed
        # Check if the button was pressed in the past
        if wasPressed == True:
            wasPressed = False # Resets the variable for next time the button is pressed
            mode = mode + 1 # Change the mode

    if mode == 0:
        print("You are in mode 0")
        my_servo.angle = 0

    elif mode == 1:
        print("You are in mode 1")
        my_servo.angle = 120
    else:
        print("Back to mode 0")
        mode = 0

  else:
      print("Slide False: No Electricity is flowing through the circuit")
      #pixels.fill((0,0,0))
      pixels.fill(OFF)
      pixels.show()
      wasPlayed = False
  time.sleep(0.1)

