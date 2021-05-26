3D 2048 Block Pack(2020/1/15 - by Fatty War, id3644 @gmail.com)

[Update V1.0 1st (2021/2/2)]
-Unity version support: Camera Depth Texture (DepthEdgeOtrho.shader)
	The "EnableDepthTexture" script does not work in Unity 2019.3 or higher.
	For Unity 2019.3 or higher, please turn on the "Camera Depth Texture" built into the Camera.

	-If the fake fog plane doesn't work, try one of the following:
	A. Example scene> Camera / Rendering / Depth Texture> On
	or
	B. URP Asset> General / Depth Texture> On

-URP(LwRP) support (Unity Editor 2019 or higher is required)
	Unity Editor: Edit> Render Pipeline> Upgrade Project Materials

-Fix "c_Wind_0" prefab material.

This document explains how to use the pack.

Introduction

    A low poly style block art pack for puzzle.
	
    * Abstract minimalistic art block.
    * The package contains a sample executable scene. (includes script)
    * Example scenes are 2D & 3D play. (Including 2D & 3D resources)
    * Quarter view and square view are available.

*Note) The quality of the included scripts can not be guaranteed.(i am just artist!).

1. Abstract minimalistic art block.

    The block consists of 11 unique geometric shapes and 1 common block.
         -11 types of geometric blocks: 2 to 2048
         -1 shared block: 4096 to infinity

2. The package contains a sample executable scene.

    You can load a scene in the editor and preview it by pressing the Run button.
     Preview scene is divided into 2D and 3D.
        -Demo2D2048 : 2D Play(Square view)
        -Demo3D2048 : 3D Play(Quarter view)
		
This asset contains:

    [Props]
    -11x Geometric block(x3 color variation / tri 14 ~ tri 204 / 256 diffuse png)
    -1x Shared block(tri 12 / 256 diffuse png)
    -1x Floor(tri 2320)

    [Textures]
    -1x Texture(Diffuse, 256x256, PNG)
    -1x 2D puzzle block sprite(Atlas), 5x Button image, 1x Background image, 1x Particle effect image.

    [Scenes]
    -Demo2D2048 : 2D Preview.
    -Demo3D2048 : 3D Preview.
    -Display : All prefab block display.

    [Shaders]
    DepthEdgeOtrho.shader : Includes a fake height fog shader for the orthographic camera.
	(Mobile supported / Perspective camera not supported)
    ex) Used for the bottom of the puzzle board in the asset store preview video.

	If the fake fog plane doesn't work, try one of the following : (Unity Editor 2019 or higher is required)
	A. Example scene> Camera / Rendering / Depth Texture> On
	or
	B. URP Asset> General / Depth Texture> On


*If you have any questions or suggestions about the assets, please contact me.(id3644@gmail.com)

Thank you for your purchase.
