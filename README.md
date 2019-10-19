# OpenSource Virtual Reality Arcade Management System

![](https://raw.githubusercontent.com/vivalite/VRArcadeSoftware/master/DOCs/Images/3.2.png)

![](https://raw.githubusercontent.com/vivalite/VRArcadeSoftware/master/DOCs/Images/1.1.PNG)

[View Gaming Station Client Screenshots](https://github.com/vivalite/VRArcadeSoftware/wiki/Gaming-Station-Client-Screenshot)

[View Managing System Screenshots](https://github.com/vivalite/VRArcadeSoftware/wiki/Managing-System-Screenshot)

## The Story
3 years ago, me and my friends had the idea to open a virtual reality arcade. So, we started preparing, register company, finding store location, researching VR game, contact game developer and finding a system we can use to manage our perspective virtual reality arcade store.

I am a software & electronic engineer with 19 years of experience and since we didn’t find any good virtual reality arcade management system at the time, I started developing our very own virtual reality arcade management system. It took me about 8 months and 22,000+ lines of code to finally complete the software and 1 more month to do internal test to work out everything smoothly. 

We went through all the initial hiccup of starting a business, such as renovation, permit, purchase and figure out a path when plan doesn’t fall all right in etc. The arcade was open. We laugh, we cry, we work hard. It was a quite good run for 2 years. At a point the beginning of this year we finally decide to close the store as the rising rent are eroding all of the profit – our own mistake of setting up store in super high-rent mall entry units. 

So, we were where we were. The virtual reality arcade management system became the legacy of my closed store. Through here I would like to contribute the virtual reality arcade management system to the great virtual reality arcade operator community and the people like you. It’s fully functional and stable, free of charge and will remain free in the future! 


## Features

- Supports 1 to 16 (or more) virtual reality gaming PC equipped with HTC VIVE. (If the controlling PC has a large screen it can support 40+ VR gaming PCs)
- In HTC VIVE VR headset game selection menu. Player do not need to take off the headset to select a game.
- Game selection menu support 2 levels deep with each level maximum 32 items. (The optimal is 9 items on first level serve as categories and 16 items on each of the sub level)
- In headset menu to show time left, exit game and call assistance.
- Start timed or manual play session. When play time is up or manually end from the front desk controlling PC, the gaming station PC will exit the game and display configurable message.
- Support VR games distribute through Steam or manual installation.
- Controlling PC can remotely reboot / turn off gaming PC and disable keyboard / mouse / USB flash drive on gaming PC.
- Individual game play time record can be further extracted for monthly billing / pay-per-use purpose.
- Waiver system integration. 
- Check-in ticket thermo printer support. 
- Raspberry Pi based gaming station status display & barcode scanner. (The code is there but lacking document on how to make the hardware and hardened Linux system.)
- Bookeo integration. (Require setup)



## Future Road Map
- Better document.
- Easy to use installer download so your won't need to compile the whole software yourself.
- Test support on the HTC VIVE PRO.
- Better interface (Both managing client and the in-headset UI).
- Have a way to hide bookeo / ticket printing / station dashboard / waver related function if not used.

## Development Environment Setup Notes
[Please check the Wiki](https://github.com/vivalite/VRArcadeSoftware/wiki)

## Setup Download
Comming soon.

## Sponsor
Currently almost all of the development for this software is done by me alone in the spare time, in addition to working on his full-time job. There is not really enough income to support a full-time developer at this point, and buying VR hardware and tools required to support all sorts of setups is quite expensive. Financially supporting helps a lot in moving things forwards. If this system helps you, please consider sponsor.


## License

BSD 3. For detail please refer to the LICENSE file in the root directory.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
