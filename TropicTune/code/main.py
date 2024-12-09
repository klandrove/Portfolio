import board
import neopixel
import time
import digitalio

import usb_hid
from adafruit_hid.keyboard import Keyboard
from adafruit_hid.keyboard_layout_us import KeyboardLayoutUS
from adafruit_hid.keycode import Keycode

kbd = Keyboard(usb_hid.devices)
layout = KeyboardLayoutUS(kbd)

# Setup NeoPixel matrix
pixel_pin = board.D6
pixel_width = 8
pixel_height = 8

pixels = neopixel.NeoPixel(
    pixel_pin, pixel_width * pixel_height, brightness=0.05, auto_write=False
)

# 8x8 Font for Letters
FONT = {
    "C": [
        0b00000000,
        0b00111000,
        0b00100000,
        0b00000100,
        0b00100000,
        0b00000100,
        0b00011100,
        0b00000000
    ],
    "D": [
        0b00000000,
        0b00011110,
        0b01000100,
        0b01000010,
        0b01000010,
        0b00100010,
        0b01111000,
        0b00000000
    ],
    "E": [
        0b00000000,
        0b00111110,
        0b01000000,
        0b00000010,
        0b01111000,
        0b00000010,
        0b01111100,
        0b00000000
    ],
    "F": [
        0b00000000,
        0b00000010,
        0b01000000,
        0b00000010,
        0b01111000,
        0b00000010,
        0b01111100,
        0b00000000
    ],
    "G": [
        0b00000000,
        0b00111110,
        0b01000100,
        0b00110010,
        0b01000000,
        0b00000010,
        0b01111100,
        0b00000000
    ],
    "A": [
        0b00000000,
        0b00100100,
        0b00100100,
        0b00100100,
        0b00111100,
        0b00100100,
        0b00011000,
        0b00000000
    ],
    "B": [
        0b00000000,
        0b00011100,
        0b00100100,
        0b00011100,
        0b00111000,
        0b00100100,
        0b00111000,
        0b00000000
    ],
    "C1": [
        0b00000001,
        0b10011100,
        0b01000011,
        0b10000010,
        0b01000000,
        0b00000010,
        0b00111000,
        0b00000000
    ],
    "D1": [
        0b00000001,
        0b10001110,
        0b01001011,
        0b10010010,
        0b01001000,
        0b00010010,
        0b01110000,
        0b00000000
    ],
    "E1": [
        0b00000001,
        0b10011110,
        0b01000011,
        0b10000010,
        0b01110000,
        0b00000010,
        0b01111000,
        0b00000000
    ],
    "F1": [
        0b00000001,
        0b10000010,
        0b01000011,
        0b10000010,
        0b01110000,
        0b00000010,
        0b01111000,
        0b00000000
    ]
}

def draw_letter(letter, x, y, color):
    """Draws a single letter at position (x, y)."""
    if letter not in FONT:
        return  # Skip undefined letters
    for row_idx, row in enumerate(FONT[letter]):
        for col_idx in range(8):  # Each row is 8 pixels wide
            if row & (1 << (7 - col_idx)):  # Check if the bit is set
                set_pixel(x + col_idx, y + row_idx, color)


def set_pixel(x, y, color):
    """Sets a pixel at (x, y) on the matrix."""
    if 0 <= x < pixel_width and 0 <= y < pixel_height:  # Boundary check
        index = y * pixel_width + x
        pixels[index] = color


def clear_matrix():
    """Clears the entire NeoPixel matrix."""
    pixels.fill(0)
    pixels.show()

def draw_matrix(letter):
    clear_matrix()
    draw_letter(letter, 0, 0, (0, 120, 250))  # Draw "H" in green at position (0, 0)
    pixels.show()


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

H = digitalio.DigitalInOut(board.D7)
H.direction = digitalio.Direction.INPUT
H.pull = digitalio.Pull.UP

J = digitalio.DigitalInOut(board.D8)
J.direction = digitalio.Direction.INPUT
J.pull = digitalio.Pull.UP

K = digitalio.DigitalInOut(board.D9)
K.direction = digitalio.Direction.INPUT
K.pull = digitalio.Pull.UP

L = digitalio.DigitalInOut(board.D10)
L.direction = digitalio.Direction.INPUT
L.pull = digitalio.Pull.UP

semi = digitalio.DigitalInOut(board.D11)
semi.direction = digitalio.Direction.INPUT
semi.pull = digitalio.Pull.UP

quote = digitalio.DigitalInOut(board.D12)
quote.direction = digitalio.Direction.INPUT
quote.pull = digitalio.Pull.UP
# Main loop
while True:
    if A.value == True:
        pixels.show()
    else:
        kbd.send(Keycode.A)
        draw_matrix("C")
    if S.value == True:
        pixels.show()
    else:
        kbd.send(Keycode.S)
        draw_matrix("D")
    if D.value == True:
        pixels.show()
    else:
        kbd.send(Keycode.D)
        draw_matrix("E")
    if F.value == True:
        pixels.show()
    else:
        kbd.send(Keycode.F)
        draw_matrix("F")
    if G.value == True:
        pixels.show()
    else:
        kbd.send(Keycode.G)
        draw_matrix("G")
    if H.value == True:
        pixels.show()
    else:
        kbd.send(Keycode.H)
        draw_matrix("A")
    if J.value == True:
        pixels.show()
    else:
        kbd.send(Keycode.J)
        draw_matrix("B")
    if K.value == True:
        pixels.show()
    else:
        kbd.send(Keycode.K)
        draw_matrix("C1")
    if L.value == True:
        pixels.show()
    else:
        kbd.send(Keycode.L)
        draw_matrix("D1")
    if semi.value == True:
        pixels.show()
    else:
        kbd.send(Keycode.SEMICOLON)
        draw_matrix("E1")
    if quote.value == True:
        pixels.show()
    else:
        kbd.send(Keycode.QUOTE)
        draw_matrix("F1")

    time.sleep(0.2)  # debounce delay


