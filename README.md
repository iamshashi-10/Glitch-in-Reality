# Glitch-in-Reality

# Glitch in Reality: An Immersive VR Space Simulation

An interactive virtual reality application developed in **Unity 6** using the **Universal Render Pipeline (URP)** designed to grant users experiential agency over complex cosmic events.This project aims to reduce cognitive load and enhance conceptual understanding of abstract physics through immersive, cause-and-effect gameplay loops.

---

## 🚀 Features & Benchmarks

The simulation features six distinct interactive cosmic benchmarks connected via a central zero-gravity hub:

* **Spacecraft Launch:** Manual liftoff sequence with real-time telemetry and speed controls.
* **Zero-G Navigation:** Smooth VR flight navigation using wormhole-based scene transitions.
* **Big Bang Simulation:** User-triggered explosion using **VFX Graph** with an interactive cosmic evolution timeline.
* **Orbital Mechanics:** Physics-driven Earth-Sun-Moon system utilizing **Newtonian N-body gravitation** and solar eclipse simulations.
* **Asteroid Collision:** Physics-driven impact scenario with adjustable kinetic energy sliders and layered particle feedback.
* **Black Hole Environment:** Custom **Shader Graph** implementation of event horizons, accretion disks, and relativistic gravitational lensing.
---

## 🛠️ Technology Stack

* **Engine:** Unity 6 (6000.4.0f1)
* **Render Pipeline:** Universal Render Pipeline (URP 17.4.0)
* **XR Framework:** XR Interaction Toolkit (v3.4.1) 
* **Tracking:** OpenXR Plugin (v1.16.1) 
* **Target Headset:** Meta Quest 2

---

## 🔧 Installation & Setup

### Prerequisites
* **Unity Editor:** Version 6000.4.0f1 
* **XR Hardware:** Meta Quest 2 (via Oculus Link or standalone build)
* **System:** Windows 10/11 with an OpenXR supported GPU 

### Step-by-Step
1.  **Clone the Repository:**
    ```bash
    git clone [repository-url]
    ```
2.  **Open in Unity:** Add the root folder in Unity Hub and ensure the editor version matches **6000.4.0f1**.
3. **Configure Render Pipeline:** Ensure `URP.asset` is assigned in `Project Settings > Graphics`.
4.  **Build Settings:** Verify all scenes (Launch, Interaction Hub, Big Bang, Orbital, Asteroid, Black Hole) are included in the build list.
5.  **Run:** Connect your Quest 2 and select **Build and Run**.

---

## 🎮 Controls

| Action | VR Input (Meta Quest 2) | Desktop Fallback |
| :--- | :--- | :--- |
| **Launch Rocket** | UI Button (Ray Interactor) | Enter Key|
| **Adjust Speed/Time** | UI Slider (Ray Interactor) | Mouse Drag|
| **Navigation** | Joystick Locomotion | WASD + Mouse  |
| **Enter Wormhole** | Fly into Trigger Collider |Walk into Trigger  |
| **Switch Cameras** | UI Button (Ray Interactor) | Mouse Click  |

---

## 📂 Project Structure

* **`Assets/Garg/`**: Big Bang simulation and VFX assets.
* **`Assets/Shashi/`**: Orbital mechanics and solar eclipse logic .
* **`Assets/DARSH/`**: Asteroid collision physics and impact effects .
* **`Assets/Ayush/`**: Black hole shaders and multi-camera systems .
* **`Assets/Srishti/` & `Assets/Siddhi/`**: Spacecraft launch, hub navigation, and portal management .

---

## 📝 Authors

* **Ayush Garg** (230254) 
* **Ayush Kumar** (230261)
* **Darsh Vikrant Patil** (230343) 
* **Shashi Bhidodiya** (230956) 
* **Siddhi Gupta** (231007) 
* **Srishti Parmar** (231036) 
---

## 📜 Acknowledgments
Special thanks to **Prof. Amar Behera** for his invaluable feedback and support throughout the development of this project.
