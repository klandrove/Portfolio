import time
import board
import digitalio
import neopixel

import usb_hid
from adafruit_hid.keyboard import Keyboard
from adafruit_hid.keyboard_layout_us import KeyboardLayoutUS
from adafruit_hid.keycode import Keycode

kbd = Keyboard(usb_hid.devices)
layout = KeyboardLayoutUS(kbd)


# BUTTON_A is an reference to the 2 buttons on the Circuit Python Express
A = digitalio.DigitalInOut(board.D1)
A.direction = digitalio.Direction.INPUT
A.pull = digitalio.Pull.UP

S = digitalio.DigitalInOut(board.D2)
S.direction = digitalio.Direction.INPUT
S.pull = digitalio.Pull.UP

D = digitalio.DigitalInOut(board.D3)
D.direction = digitalio.Direction.INPUT
D.pull = digitalio.Pull.UP

F = digitalio.DigitalInOut(board.D4)
F.direction = digitalio.Direction.INPUT
F.pull = digitalio.Pull.UP

G = digitalio.DigitalInOut(board.D5)
G.direction = digitalio.Direction.INPUT
G.pull = digitalio.Pull.UP

H = digitalio.DigitalInOut(board.D6)
H.direction = digitalio.Direction.INPUT
H.pull = digitalio.Pull.UP

J = digitalio.DigitalInOut(board.D7)
J.direction = digitalio.Direction.INPUT
J.pull = digitalio.Pull.UP

K = digitalio.DigitalInOut(board.D8)
K.direction = digitalio.Direction.INPUT
K.pull = digitalio.Pull.UP

L = digitalio.DigitalInOut(board.D9)
L.direction = digitalio.Direction.INPUT
L.pull = digitalio.Pull.UP

semi = digitalio.DigitalInOut(board.D10)
semi.direction = digitalio.Direction.INPUT
semi.pull = digitalio.Pull.UP

quote = digitalio.DigitalInOut(board.D11)
quote.direction = digitalio.Direction.INPUT
quote.pull = digitalio.Pull.UP

pixels = neopixel.NeoPixel(board.NEOPIXEL, 10, brightness=0.1, auto_write=False)

while True:
    if A.value == True:
        pixels.show()
    else:
        kbd.send(Keycode.A)
        print("A")
    if S.value == True:
        pixels.show()
    else:
        kbd.send(Keycode.S)
        print("S")
    if D.value == True:
        pixels.show()
    else:
        kbd.send(Keycode.D)
        print("D")
    if F.value == True:
        pixels.show()
    else:
        kbd.send(Keycode.F)
        print("F")
    if G.value == True:
        pixels.show()
    else:
        kbd.send(Keycode.G)
        print("G")
    if H.value == True:
        pixels.show()
    else:
        kbd.send(Keycode.H)
        print("H")
    if J.value == True:
        pixels.show()
    else:
        kbd.send(Keycode.J)
        print("J")
    if K.value == True:
        pixels.show()
    else:
        kbd.send(Keycode.K)
        print("K")
    if L.value == True:
        pixels.show()
    else:
        kbd.send(Keycode.L)
        print("L")
    if semi.value == True:
        pixels.show()
    else:
        kbd.send(Keycode.SEMICOLON)
        print(";")
    if quote.value == True:
        pixels.show()
    else:
        kbd.send(Keycode.QUOTE)
        print("'")

    time.sleep(0.2)  # debounce delay
