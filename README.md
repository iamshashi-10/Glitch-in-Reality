# Glitch-in-Reality

README: Glitch in Reality
Glitch in Reality is an immersive virtual reality (VR) simulation built in Unity 6 that allows users to explore and manipulate complex cosmic phenomena. By transitioning from passive 2D learning to an active 3D environment, the project aims to reduce cognitive load and enhance understanding of abstract physics and astronomy.  
+4

🚀 Project Overview
The simulation serves as a physics laboratory for celestial mechanics, featuring six distinct, interactive benchmarks connected through a central navigation hub.  
+3

Core Benchmarks
Spacecraft Launch: Manually execute liftoff with real-time telemetry and speed controls.  
+2

Zero-G Navigation: Pilot a spacecraft through a central hub to reach themed wormhole portals.  
+1

Big Bang Simulation: Trigger a VFX-driven explosion and navigate an interactive cosmic timeline.  
+2

Orbital Mechanics: Explore the Earth-Sun-Moon system driven by a Newtonian N-body engine, including solar eclipse events.  
+2

Asteroid Collision: Manipulate kinetic energy sliders to observe a planetary impact with layered particle effects.  
+2

Black Hole Environment: Observe relativistic phenomena like event horizons and gravitational lensing through custom shaders.  
+2

🛠 Technology Stack
Engine: Unity 6 (6000.4.0f1)   
+2

Render Pipeline: Universal Render Pipeline (URP) 17.4.0   
+1

XR Framework: XR Interaction Toolkit 3.4.1   
+2

Target Hardware: Meta Quest 2 (via OpenXR)   
+1

Visuals: Shader Graph (relativistic anomalies) and VFX Graph (explosions)   
+1

🔧 Installation & Setup
Prerequisites
Unity Hub with Editor version 6000.4.0f1   
+1

Git 2.30+   

Meta Quest 2 with Oculus Link or a compatible OpenXR GPU for desktop testing   

Opening the Project
Clone this repository to your local machine.  

Add the project in Unity Hub and wait for asset import (approx. 5–15 minutes).  

Ensure URP is assigned in Project Settings > Graphics.  

Verify that all benchmark scenes are added to the Build Settings.  

🎮 Controls
Action	VR Input	Desktop Fallback
Locomotion	Joystick / Teleport	
WASD + Mouse

Interactions	XR Ray Interactor	
Mouse Click

Launch Rocket	UI Button (Ray)	
Enter Key

Adjust Parameters	UI Sliders (Ray)	
Mouse Drag

📂 System Architecture
The project uses an event-driven, scene-based architecture.  

Assets/Scripts/: Contains core modules for N-body gravity, camera tracking, and scene management.  
+1

Assets/Shaders/: Custom Shader Graphs for the Sun, Black Hole, and Heat Distortion.  
+2

Assets/Prefabs/: Optimized XR Origin and planetary impact assets.  
+2

⚠️ Known Limitations
Physics: Asteroid movement is currently kinematic and does not account for atmospheric drag or fragmentation.  
+1

UI: The Big Bang timeline uses legacy OnGUI(), which renders in screen-space and may break VR immersion.  
+1

Transitions: Scene loading is synchronous, which may cause brief frame drops during transitions.  
+1

📝 Credits
Developers: Ayush Garg, Ayush Kumar, Darsh Vikrant Patil, Shashi Bhidodiya, Siddhi Gupta, and Srishti Parmar .
Special Thanks: Prof. Amar Behera for guidance and support.
