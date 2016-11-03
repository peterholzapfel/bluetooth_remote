﻿/*Begining of Auto generated code by Atmel studio */
#include <Arduino.h>

/*End of auto generated code by Atmel studio */


// Variablen vergabe

#define trigPin1 13
#define echoPin1 12


#define trigPin2 11
#define echoPin2 10



int LED01      = 3;
int LED02      = 4;
int LED03      = 5;
int LED04      = 6;
int LED05      = 7;
int LED06      = 8;
int LED07      = 9;
int Taster01 ;
int Taster02;
int Pause   = 1000; //sind 1000 mili Sekunden
int val = 0;    
int delay_time = 50 ;                // variable for reading the pin status
// the setup function runs once when you press reset or power the board
void setup() {
	// initialize digital pin 13 as an output.
	pinMode(LED01, OUTPUT);
	pinMode(LED02, OUTPUT);
	pinMode(LED03, OUTPUT);
	pinMode(LED04, OUTPUT);
	pinMode(LED05, OUTPUT);
	pinMode(LED06, OUTPUT);
	pinMode(LED07, OUTPUT);
	
	 pinMode(trigPin1, OUTPUT);
	 pinMode(echoPin1, INPUT);
	 
	 pinMode(trigPin2, OUTPUT);
	 pinMode(echoPin2, INPUT);
	 

//	pinMode(Taster01,   INPUT);     // Taster PIN = Eingang
//	pinMode(Taster02,   INPUT); 

// Bluetooth

Serial.begin(9600); //set baud rate
}

// the loop function runs over and over again forever

bool isActive(int sensor){
	
		int trigPin,echoPin ;
		if (sensor == 1){
			trigPin= trigPin1;
			echoPin = echoPin1 ;
		}
		if (sensor == 2){
			trigPin= trigPin2;
			echoPin = echoPin2 ;
		}

		long duration, distance ;
		digitalWrite(trigPin, LOW);  // Added this line
		delayMicroseconds(1); // Added this line
		digitalWrite(trigPin, HIGH);
		//  delayMicroseconds(1000); - Removed this line
		delayMicroseconds(10); // Added this line
		digitalWrite(trigPin, LOW);;
		duration = pulseIn(echoPin, HIGH);
		distance = (duration/2) / 29.1;
		
		if ((distance < 10)) {  // This is where the LED On/Off happens
			return true;
		}
		else {
			return false;
		}
		return false;
}
void sendCommand(int command){
	if(!Serial.available())
	{
		Serial.print(command);
	}	
}
void play(){
	sendCommand(4);
	digitalWrite(LED02, HIGH);	
}
void previous_song(){
	sendCommand(3);
	digitalWrite(LED03, HIGH);
	delay(100);
}
void next_Song(){
	sendCommand(5);
	digitalWrite(LED01, HIGH);
	delay(100);	
} 

void reduce_volume(){
	sendCommand(1);
	digitalWrite(LED05, HIGH);	
	delay(delay_time);
	digitalWrite(LED05, LOW);
	delay(delay_time);
}
void increase_volume(){
	sendCommand(2);
	digitalWrite(LED04, HIGH);
	delay(delay_time);
	digitalWrite(LED04, LOW);	
	delay(delay_time);
}
bool isPlay(int first,int second){
	int t = 50 ;
	while (t > 0) {
		delay(10);
		t = t-1 ;
		if	(((isActive(first) && isActive(second)) == 0) && (t > 1)){
			return false;
		}
	}
	return true ;
}
void loop() {
		bool break_flag;
		int first_sensor;
		int second_sensor;
		int t;
		int x;
		digitalWrite(LED01, LOW);
		digitalWrite(LED02, LOW);
		digitalWrite(LED03, LOW);
		digitalWrite(LED04, LOW);
		digitalWrite(LED05, LOW);
		digitalWrite(LED06, LOW);
		digitalWrite(LED07, LOW);

		first_sensor = 1;
		second_sensor = 2;
		while (1){
		while (1) {
			digitalWrite(LED06, HIGH);
			digitalWrite(LED07, LOW);
			if (isActive(1)) {
				first_sensor = 1;
				second_sensor = 2;           // check if the input is HIGH
				break;
			}
			if (isActive(2)) {            // check if the input is HIGH
				first_sensor = 2;
				second_sensor = 1;
				break;
			}
		}
		t = 5 ;
		x = 10 ;
		break_flag = false;
		while (t > 0)
		{
			digitalWrite(LED06, LOW);
			digitalWrite(LED07, HIGH);
			delay(5);
			while (x > 0) {
				if (isActive(second_sensor)) {
					if (second_sensor == 1){
						if (isPlay(first_sensor,second_sensor)) {
							play();
							while (isActive(first_sensor) && isActive(second_sensor)) {
								delay(15);
							}
							break_flag = true;
							break;	
						}
						// previous Song
						previous_song();
						break_flag = true;
						break;
					}
					if (second_sensor == 2){
						if (isPlay(first_sensor,second_sensor)) {
							play();
							while (isActive(first_sensor) && isActive(second_sensor)) {
								delay(15);
							}
							break_flag = true;
							break;
						}
						// Next Song
						next_Song();
						break_flag = true;
						break;
					}
				}
				delay(5);
				x = x-1;
			}
			if (break_flag){
				delay(100);
				break;
					}
			t = t-1;	
		}
		if (break_flag){
			delay(100);
			break;
		}
		if (isActive(first_sensor)){
			if (first_sensor == 1){
				while (isActive(first_sensor)) {
					reduce_volume();
					
				}
				break;
				
			}
			if (first_sensor == 2){
				while (isActive(first_sensor)){
					increase_volume();
					
				}
				break;
				
			}
		}
		
		}
		delay(500);
		}
	
	
