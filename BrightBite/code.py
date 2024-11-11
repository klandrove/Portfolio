# import the necessary libraries
import board
import pwmio
from adafruit_motor import servo
import time
import analogio

# create an analog input object for the photocell
photocell = analogio.AnalogIn(board.A3)

# create PWMOut objects
pwm = pwmio.PWMOut(board.A1, duty_cycle=2 ** 15, frequency=50)
pwm2 = pwmio.PWMOut(board.A2, duty_cycle=2 ** 15, frequency=50)

# Create servo objects
top_servo = servo.Servo(pwm)
bottom_servo = servo.Servo(pwm2)

# create a variable to store the state of the scoop
scoop = False

while True:

    time.sleep(1)
    # read the value of the photocell
    potVoltage = photocell.value

    # check if the value of the photocell > 20000
    # this indicates that the light is on
    if potVoltage>20000:
        # check the value of scoop, if scoop equals false
        if scoop == False:
            # set scoop to True
            scoop = True
            # move the top servo to 180 degrees
            top_servo.angle = 180
            time.sleep(1)
            # move the bottom servo to 150 degrees
            bottom_servo.angle = 150
            time.sleep(1)
            # move the top servo to 0 degrees
            top_servo.angle = 0
            time.sleep(1)
            # move the bottom servo to 30 degrees
            bottom_servo.angle = 30

    # check if the value of the photocell < 3000
    # this indicates that the light is off
    if potVoltage<3000:
        scoop = False




