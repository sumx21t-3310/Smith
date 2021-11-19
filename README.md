# ShooterWeaponSystemForUnity
An FPS / TPS framework that allows you to create weapons without code.

[comment]: <> (Give it a clear and cool name)

The Weapon System is a framework that allows you to create any kind of weapon for FPS/TPS.
It was created based on the weapons in Riot Games' [Valorant](https://playvalorant.com/en-us/arsenal/).

# Features.
* For general weapons, the inspector is complete. You can create weapons with no code. 
* The behavior can be extended by simply implementing various interfaces and base classes. 
* No dependency on effects or built-in audio. Playback timing is represented by UnityEvent. 
* Projectile and HitScan can be selected. You can select the strength of the sniper. 
* Can change the firing position of bullets. You can select whether or not there is an advantageous wall. 
* Changeable magazine type. Trigger happy is not a dream.
* Changeable bullet storage method. Create your own code to get bullets out of your inventory.


[comment]: <> (gif of me tweaking the inspector)
## Implemented Weapon Actions
- Aim
  - Aim
  - Scope Aim
  - Zoom Only Aim
- Attack
  - Shooting
  - ShotgunShooting
- Control
  - Aim Switching
  - Selectable
  - EventInvoke
- Interact
  - Grab
- Template
  - Interval Action Base


# Requirement

[comment]: <> (List the libraries required to run the "Weapon System")

* Unity 2019 LTS Later.
* [mackysoft - Unity-SerializeReferenceExtensions](https://github.com/mackysoft/Unity-SerializeReferenceExtensions)


# Usage
## Install
### Unity Package Manager
#### git url: `https://github.com/NebusokuDev/ShooterWeaponSystemForUnity.git?path=Assets/NebusokuDev/ShooterWeaponSystem`

## Setup
[comment]: <> (Paste images of various inspectors)
1. create an empty game object. 2.
Attach a SingleActionWeapon, DualActionWeapon, or Generic Weapon to the empty game object. 3.
Attach an Input that matches each Weapon. 4.
Set the Action, Magazine, and Ammo Holder according to the weapon type. 5.
If you are using ObjectPool, such as ShootingAction, create an empty game object and attach an ObjectPoolBinder.
## Extend

# Note
[comment]: <> (Write any notes you have)
* If you play the game with the Inspector display open, the frame rate will drop noticeably. Please collapse the Inspector display before playing it.
* `Serializable` attribute must be added to your code.

# Contact
If you have any bugs, improvements, requests, or implementation questions, please register them in Issues.
Pull requests are also welcome.


# License

[comment]: <> (specify the license)

"Shooter Weapon System for Unity" is under [MIT license](https://en.wikipedia.org/wiki/MIT_License).

Translated with www.DeepL.com/Translator (free version)
