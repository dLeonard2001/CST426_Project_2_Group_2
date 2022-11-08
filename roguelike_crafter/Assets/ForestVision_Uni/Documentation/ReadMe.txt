
ForestVision_Uni 1.0

mikecbauervision@gmail.com

----------------------

Getting Started!!

To make things as easy to use as possible, I have placed all of your key assets inside the main ForestVision_Uni folder
From here, you will find everything you need.  

*The only folder that kind of needs an explanation is the Textures folder. These are the source textures Unity creates 
when you create it's trees.

Source textures for your barks, foliage, grass, etc. are found under:

/ForestVision_Uni / Materials:

-Barks   / Textures
-Empties / Textures
-Grasses / Textures
-Leaves  / Textures
-Plants  / Textures

I have supplied some custom meshes for you to experiment with in your designs. They don't all
work great with the Tree Creator system, but they are there for you to play with regardless.

Note, if you go to: /ForestVision_Uni / Uni Trees FV Specials
you will find a few examples of trees that use these custom meshes. I was able to get some decent results.


Uni Bushes

	These are a group of young plants that resemble their older counterparts. Spread these around to show
	new trees are growing.

Uni Grass

	A collection of good looking grass/weed clumps to help you fill out an area. Some contain up to 3 different
	textures to keep things looking varied.

	- You can find 25 materials ready for your use in: /ForestVision_Uni / Materials / Grasses

Uni Plants

	Admittedly, this are not as easy to design so there isn't alot of variety here yet, but there
	are a couple that you could duplicate and apply new textures to to give you some variety.

Uni Trees

	Over 100 trees at your disposal, each species comes with 4 ages. more to come with each update!
	Inside of this folder you'll find:
	- FV_Specials
		These are a couple of trees that use my custom branches for the "leaves"
	- Group B
		This represents an easy way to duplicate and easily make new varieties of trees. If you duplicate
		the Group B folder, you will duplicate all of the trees inside as well, which will give you
		an entire new group of trees you can tweak, while saving the rest.  Group B is essentially
		me duplicating all of the trees directly in the /Uni Trees folder, and then changing their textures
		and tweaking tree parameters making new trees easily.  This method will keep you from having
		to create trees from scratch, which will save you a ton of time!

	- Megas
		These trees are just me pushing Tree Creator as far as I can.  I wanted to see how many leaves, branches, etc.,
		I could add before Tree Creator gave up on me.  These trees would be fun to continue working with... ;)


I will continue to grow this collection of trees with each update!


-------------------------------------------------------------------

Your special tools which you will only find with BauerVision products!

Added for free to ForestVision Uni so you can enjoy what I believe are essential tools.
Once Tree Texture Suite is released, all updates to these tools will only be found within
that product, but you'll still have all of this core functionality!

-------------------------------------------------------------------
* * * * * * * * * * * * * * * * * *

Tree Texture Suite

* * * * * * * * * * * * * * * * * *

-----------------------------

Foliage Creator

-----------------------

To use Foliage Master  -> Unity 2017: 
* Note I do not recommend, or support 2018 with this product yet.

/ForestVision_Uni / Foliage Creator: Foliage Master
1) Open the Substance to reveal the material and the texture maps.
2) Click on the material ( VickysVine ), and scroll down to the Source Images
 - load in each channel
 - Branch Mask should be the black and white images which depict branches for best results
   as the substance will apply leaves to whatever is white.
 - Branch Texture should match the texture you are applying to the bark of your tree
 - Summer leaf 1 and 2 are compeltely up to you to play around with.
   Source leaf textures can be found: 
    /ForestVision_Uni / Foliage Creator / Leaves
 - Flowers can be sourced from:
    /ForestVision_Uni / Foliage Creator / Flowers

3) Just above the Source Images section, you will see the Seasonal Blend slider.
   Use this to adjust the season of your branch. 
    0 - 0.25   = Winter to Spring
    0.25 - 0.5 = Spring to Summer
    0.5 - 0.75 = Summer to Fall
    0.75 - 1.0 = Fall to Winter

4) Tweak settings for each parameter: Spring Flowers, Summer leafs 1 and 2, How you want the Fall colors to look,
   and a few simple options for what empty branches will look like in the winter.
   * Note Winter has the option to remove the branch entirely from the texture, this is perfect if you need to create
   Card textures to fill up the tree and not have stray branches sticking out where they shouldn't be.
 
   I recommend applying this initial material to either an empty plane mesh, or one of the supplied meshes found in: 
   /ForestVision_Uni / Meshes, so you can see how the material changes with your parameter tweaks.  One you apply the textures
   to the Unity tree you won't see live updates anymore.

5) Once you are happy with the textures, rename "VickysVine" to something appropriate for what you are making, as this will be
   the new prefix of your exported texture. Then where you can set the shader ( Standard Specular setup), right click and choose
   - Export Bitmaps (remapped alpha channels)
   - Choose you preferred export folder, I dump mine in /ForestVision_Uni / Foliage Creator/ Output
   -Then refresh Unity to force the import of the newly created images. I typically just click outside of Unity, and then click 
   back in to force the import.
   - Now you can go to /ForestVision_Uni / Materials / Leaves, duplicate one of the premade materials, for example "Leaves 12"
   and add in your new textures. Then just apply the material as you see fit and done!

   Note: if you want custom sizes, be sure to scroll all the way to the bottom and "Override" for your chosen platform.


-----------------------

To use Color_Adjustor: -> Unity 2017

* Note I do not recommend, or support 2018 with this product yet.

This is a perfect tool to generate your basic maps (diffuse, normal, glossiness) from a single texture maybe you took yourself, or found online. 
Designed to work with Unity's Tree Creator Leaves shader.

* Future update will contain translucency and shadow offset as well.

/ForestVision_Uni / Foliage Creator: Color_Adjuster
1) Open the Substance to reveal the material and the texture maps.
2) Click on the material ( Multi-base-branch), and scroll down to the Source Image
 - load in your new texture
3) Tweak image with basic parameter changes within the Input rollout which will tweak your new image in a few basic ways,
   and even add in a little bit of noise to vary the look as you see fit. Don't forget to play with the Relief settings to get your normal
   looking right!
4) Once you are happy with the textures, rename "Multi-base-branch" to something appropriate for what you are making.
   Then where you can set the shader ( Standard Specular setup), right click and choose
   - Export Bitmaps (remapped alpha channels)
   - Choose you preferred export folder
   -Then refresh Unity to force the import of the newly created images. 
   - Now you can add in your new textures to your new material!

   Note: if you want custom sizes, be sure to scroll all the way to the bottom and "Override" for your chosen platform.




-----------------------

To use TrunkBlender:-> Unity 2017

* Note I do not recommend, or support 2018 with this product yet.

This is a perfect tool to generate new barks based on your current collection of bark imagery.


/ForestVision_Uni / Materials / Barks: Trunk Blender

1) Open the Substance to reveal the material and the texture maps.
2) Click on the material ( TropicalBarky1), and scroll down to the Source Images
 - load in your textures to blend together
3) Back at the top, find the Blend rollout, and use the Position slider to control the amount of blending
   0 = all source image 1, and 1 = all source image 2.
4) Tweak until you find what you were looking for.
  -Note you have complete control of each source image to alter as you see fit, including....
  the "Make it Tile" option, just in case you're in a rush and didn't have time to make your bark texture seemless!
  - Under Effect, you have a simple way to add some moss over top of your bark.
5) When you're happy with your new bark texture, export the same way as detailed above, and apply to new materials.





-----------------------

Bonus

-----------------------

FV_TextureAdapter

You might be familair with this from my other product Substance Blender, or ForestVision, but I added it in here as well
  because I think it's just that useful.  Perfect for making custom ground materials! Use it the same way as all the rest of 
my Substance tools.

----------------------

FV_ResizeTreeAtlas

Still quite new, and under development, but you can use this tool to increase the resolution
of your Unity tree textures above the 1K resolution they default to.

It's pretty straightforward to use, and for now only works with 2 atlassed textures, a bark and the leaves.  
I'll be adding in more texture options down the road.

- Add in the original source image for both the Bark and the Foliage, tweak some basic parameters if you desire,
and then just like I have explained already, export your new textures, apply to a new Tree Creator Leaves material, and apply to
the base level of any tree you like
--replacing the Optimized Leaf Material

Note, currently, you will lose the built in Ambient Occlusion Tree Creator generates, but maybe it's worth it to regain
texture resolution...

As mentioned, this one is still under development, but it works enough that I wanted you to have it.

---------------------

Autumnizer

Takes a single input texture of a full branch, for example maybe you found a great image online, but you'd like to see a little
autumn love applied to it.  Autumnizer, still under development, will tweak the colors of your image with a slider that allows you
to control how the color change is applied to your branch. You control how you want the fall version of this branch to look, then blend
to get the perfect result.
Note, this will affect the entire image, you will not get the same result as if you used Foliage Master, but can allow you to quickly turn
Summer leaves to Fall!

----------------------------------------------------------------------------


I really hope you enjoy this new addition to the ForestVision and BauerVision family! Feel free to contact me with questions, comments, or suggestions!


-----------------------

"One or more textures on this 3D model have been created with photographs from Textures.com.
These photographs may not be redistributed by default; please visit www.textures.com for more information."