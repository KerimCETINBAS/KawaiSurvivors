// NOTE: Shader automatically converted from Godot Engine 4.3.stable.mono's CanvasItemMaterial.

shader_type canvas_item;
render_mode blend_mix;

uniform float Speed = 1.0f;
uniform float Distance = 10.0f;

void vertex() {
	if (VERTEX.y < 0.0) {
		VERTEX += vec2(sin(TIME * Speed) * Distance, 0);
	}
}