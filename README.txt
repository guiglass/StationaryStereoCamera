# GravityVR - PyOpenGL and PyOpenVR physics simulation

This program was originally written for Python3.5 (for future compatibility with TensorFlow on Windows) but appears to run fine using Python2.7.
If you intend to run this in OpenVR with an HTC Vive or Oclus Rift head mounted display (HMD) then please ensure that all PyOpenVR, PyOpenGL, PyQt4 and Numpy v1.12.1+ are installed.
After which you may simply launch start_openvr.py and look for the promp that states "Please choose a scene number:".

Or if you do not have an HMD available you may instead run the start_pyqtgraph.py file to bring up a basic GUI built using PyQtGraph to display the simulation on a typical monitor.

Note that when running in OpenVR please be sure that the window named "OpenVR Gravitation Demo" is in the foreground and that you have clicked on it prior to pressing any keyboard control keys.

The Keyboard Controls keys are very simple (push and hold one at a time) to navigate around the scene and include the ability to change the size and time scale.

Keymap:
* "w" key = move the scene forward.
* "s" key = move the scene backward.
* "a" key = move the scene left.
* "d" key = move the scene right.

* "r" key = move the scene up.
* "f" key = move the scene down.

* "+" key = zoom in.
* "-" key = zoom out.
* "up arrow" key = increase timescale.
* "down arrow" key = decrease timescale.

* "space" key = Reset all items to original location.
* "esc" key = quite application.

Screenshot from OpenVR:
![alt tag](https://raw.githubusercontent.com/guiglass/StationaryStereoCamera/master/SceneLayout.png)