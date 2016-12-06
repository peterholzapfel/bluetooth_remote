﻿/*Begining of Auto generated code by Atmel studio */
#include <Arduino.h>

/*End of auto generated code by Atmel studio */


// Variablen vergabe

#define trigPin1 3
#define echoPin1 2


#define trigPin2 8
#define echoPin2 7



int LED01      = 10;
int LED02      = 6;
int Taster01 ;
int Taster02;
int Pause   = 1000; //sind 1000 mili Sekunden
int val = 0;    
int delay_time = 200 ;                // variable for reading the pin status
// the setup function runs once when you press reset or power the board
void setup() {
	// initialize digital pin 13 as an output.
	pinMode(LED01, OUTPUT);
	pinMode(LED02, OUTPUT);
	
	 pinMode(trigPin1, OUTPUT);
	 pinMode(echoPin1, INPUT);
	 
	 pinMode(trigPin2, OUTPUT);
	 pinMode(echoPin2, INPUT);
	 

//	pinMode(Taster01,   INPUT);     // Taster PIN = Eingang
//	pinMode(Taster02,   INPUT); 

// Bluetooth

Serial.begin(9600); //set baud rate
Serial.print("AT+BT-Remote");
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
}
void previous_song(){
	sendCommand(3);
	delay(100);
}
void next_Song(){
	sendCommand(5);
	delay(100);	
} 

void reduce_volume(){
	sendCommand(1);
	delay(delay_time);
}
void increase_volume(){
	sendCommand(2);
	delay(delay_time);
}
bool isPlay(int first,int second){
	int t = 50 ;
	while (t > 0) {
		delay(20);
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
		digitalWrite(10, LOW);
		first_sensor = 1;
		second_sensor = 2;
		while (1){
			while (1){
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
			while (t > 0){
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
		delay(500);
		}
		
		}
}
	
	

