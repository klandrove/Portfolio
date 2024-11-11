import board
import pwmio
from adafruit_motor import servo
import time
import analogio

photocell = analogio.AnalogIn(board.A3)

# create PWMOut objects
pwm = pwmio.PWMOut(board.A1, duty_cycle=2 ** 15, frequency=50)
pwm2 = pwmio.PWMOut(board.A2, duty_cycle=2 ** 15, frequency=50)

# Create servo objects
top_servo = servo.Servo(pwm)
bottom_servo = servo.Servo(pwm2)

scoop = False

while True:

    time.sleep(1)
    potVoltage = photocell.value
    print("Analog Voltage:" + str(potVoltage))
    print(str(scoop) + "??")

    if potVoltage>20000: #when the timer goes off save a timestamp of when that happened
        # check the value of scoop, if scoop equals false
        if scoop == False:
            scoop = True
            top_servo.angle = 180
            time.sleep(1)
            bottom_servo.angle = 150
            time.sleep(1)
            top_servo.angle = 0
            time.sleep(1)
            bottom_servo.angle = 30

    if potVoltage<3000:
        scoop = False




