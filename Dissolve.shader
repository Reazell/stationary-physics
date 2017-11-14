Shader "Hidden/Dissolve"{
	Properties {
		_MainTex ("Texture (RGB)", 2D) = "white" {}
		_SliceGuide ("Dissolve (RGB)", 2D) = "white" {}
		_DissolveAmount ("Dissolve Intensivity", Range(0.0, 1.0)) = 0.0
    }
    SubShader {
		Tags { "RenderType" = "Opaque" }
    CGPROGRAM
		#pragma surface surf Lambert addshadow
		struct Input {
		float2 uv_MainTex;
		float2 uv_SliceGuide;
		float _DissolveAmount;
    };
		sampler2D _MainTex;
		sampler2D _SliceGuide;
		float _DissolveAmount;
	

		void surf (Input IN, inout SurfaceOutput o) {
	
		clip(tex2D (_SliceGuide, IN.uv_SliceGuide).rgb - _DissolveAmount);
		o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
		}
		ENDCG
    } 
		
}