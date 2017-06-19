# RAMDiskCopy
Creates a RAM disk and copies a specified folder to it leaving a junction so that it may be accessed as if it never left all while
leaving a backup copy of the folder behind in case disaster strikes and your RAM disk goes bye-bye. Optionally, it can also copy the
folder back to its original location so that any changes made to it are kept between reboots.

I basically wrote this to ease the pains of having to create a RAM disk, manually copy the folder over and then create a junction point.
It's not terribly difficult to do and there are many great utilities out there that make it much easier to do, but I wanted something
that would do it for me and this makes putting all that extra RAM to good use much easier.

Works great for Steam games, virtual machines and many other uses. Won't work on your Windows folder, though. There are safeguards in
place for that, but I wouldn't recommend trying to circumvent them.

This is also an early project for me, so things are a bit amature and messy.

This program relies on ImDisk Toolkit to be installed to create the RAM disks. It can be found here:

https://sourceforge.net/projects/imdisk-toolkit/

Early usage video here: https://www.youtube.com/watch?v=b4W776OoY5s

![Alt text](https://github.com/havenvanheusen/RAMDiskCopy/blob/master/RAMDiskCopy.jpg?raw=true "RAMDiskCopy")
