const int buttonPin = 2;
const int ledPin = 13;
int buttonState = 0;


void setup() {
    Serial.begin(9600);
    pinMode(buttonPin, INPUT);
}


void loop() {
    buttonState = digitalRead(buttonPin);
    Serial.println(buttonState);
    delay(100); // Wait 100 milliseconds
    
    /*
    if (buttonState == HIGH) { // Button pressed
        digitalWrite(ledPin, HIGH); // Turn LED on
    } else {
        digitalWrite(ledPin, LOW); // Turn LED off
    }
    */
}
