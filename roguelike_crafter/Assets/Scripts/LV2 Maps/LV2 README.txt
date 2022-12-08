Here is the current implementation of our LV2 using the perlin map noise
I have modulated all of the data of the map to go into the data folder which are NoiseData.cs, TerrainData.cs, TextureData.cs and UpdatableData.cs.
So that data can be interchanged and used however we like without messing with the generation scripts. 
I've have also implemented normals for the mesh for the normal lighting and custom shader and I have created collisions to the mesh.
I've also added a falloff map to scatter our land out.
Finally this map can be endless based on how far the player will go

WARNING: SOME OF MY PROJECT FILES GOT SCREWED UP SO PLEASE BACKUP YOUR CURRENT EXISTING PROJECT BEFORE INTEGRATING

============================================================ TO USE IT ================================================================================
You can use this by creating a empty game object as your map generator
    within this game object create a plain of the map generator

Next create an new empty game object. This will be the mesh
    give this game object the mesh filleter and renderer and give it the "Hide On Display" scripts
        this mesh will act as the preview mesh of what the map will look like.

For scripts, on the map generator game object give these things:

    The "Map Generator" script
        Assign the following with these values
            Terrain Data -> Default Terrain (within LV2 Maps/ Terrain Assets)
            Noise Data -> Default Noise (within LV2 Maps/ Terrain Assets)
            Texture Data -> Default Texture (within LV2 Maps/ Terrain Assets)
            Terrain Material -> Just give it a URP material (Explained in Known Issues)
            Optional : Chunk Size Index -> 3
            Optional : Flatshaded Chunk Size Index -> 2

    The "Map Display" script
        Assign the following with these values
            Texture Renderer -> Plain (found in the child)
            Mesh Filter -> Mesh game object
            Mesh Renderer -> Mesh game object

    The "Endless Terrain" script
        In Detail Levels add 1 element and give the Visible Dst Threshold -> 400
        Set the view to the player
        Map Material -> use the same material in Terrain Material in the Map Generator script

========================================================== KNOWN ISSUES =============================================================================
This map has a problem with the materials because it cannot be converted to the URP due to the custom shader associated with it. As of typing this I have not found 
a solution to this. I have an example of what this SHOULD look like but due to the URP I cannot showcase this aspect of the map.

The current grid spawner only works in 1 location. This is due to the rays cannot find the vector3 of that give mesh so it gives me the y threshold of the general area.

1 mysterious issue is that my project has cloud saved has been disabled for some reason. I've haven't found the reason why it...

Layers gotten deleted for some reason???

Warnings on initial project startup

=====================================================================================================================================================

GOOD LUCK on integration. If you have any questions contact me ASAP!