Shader "MiniCraft/Mobile/AlphaTest"
{
	Properties
	{
		_Color ("Main Color", Color) = (1,1,1,1)
		_Cutoff ("Alpha cutoff", Range (0,1)) = 0.5
		_MainTex ("Base (RGB)", 2D) = "white" {}
	}

	SubShader
	{
		Pass
		{
			Name "BASE"
	        Tags
	        {
	            "IgnoreProjector"="True"
	            "Queue" = "Transparent"
	            "RenderType" = "TransparentCutout"
	        }
	        
			Cull Off 
			AlphaTest Greater [_Cutoff]	
				
			SetTexture [_MainTex]
			{
				constantColor [_Color]
				combine texture * constant
			}
		}
	}
    FallBack "Transparent/Cutout/VertexLit"
}