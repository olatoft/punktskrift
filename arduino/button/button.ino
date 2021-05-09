const int buttonPin = 2;
const int ledPin = 13;
int buttonState = 0;


void setup() {
    pinMode(ledPin, OUTPUT);
    pinMode(buttonPin, INPUT);
}


void loop() {
    buttonState = digitalRead(buttonPin);
    
    if (buttonState == HIGH) { // Button pressed
        digitalWrite(ledPin, HIGH); // Turn LED on
    } else {
        digitalWrite(ledPin, LOW); // Turn LED off
    }
}
