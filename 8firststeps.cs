using System;
using System.Collections.Generic;
using System.Linq;
using Fusee.Base.Common;
using Fusee.Base.Core;
using Fusee.Engine.Common;
using Fusee.Engine.Core;
using Fusee.Math.Core;
using Fusee.Serialization;
using Fusee.Xene;
using static System.Math;
using static Fusee.Engine.Core.Input;
using static Fusee.Engine.Core.Time;

namespace Fusee.Tutorial.Core
{
public class FirstSteps : RenderCanvas
{
   private SceneContainer _scene;
   private SceneRenderer _sceneRenderer;
   private float _camAngle = 0;
   private TransformComponent _cubeTransform;
   private TransformComponent _cubeTransform1;
   private TransformComponent _cubeTransform2;

        
public override void Init()
{
            
   RC.ClearColor = new float4(1.0f, 0, 1.0f, 1.0f);

            
           
           
     _cubeTransform = new TransformComponent {Scale = new float3(1, 1, 1), Translation = new float3(0, 0, 0)};
     var cubeMaterial = new MaterialComponent
            
     {
     Diffuse = new MatChannelContainer {Color = new float3(214, 49, 203)}, 
     Specular = new SpecularChannelContainer {Color = float3.One, Shininess = 4}
     };
     var cubeMesh = SimpleMeshes.CreateCuboid(new float3(10, 10, 10));

            
            _cubeTransform1 = new TransformComponent {Scale = new float3(1, 1, 1), Translation = new float3(0, 0, 20)};  	
            var cubeMaterial1 = new MaterialComponent
            {
            Diffuse = new MatChannelContainer {Color = new float3(128, 49, 214)},
             Specular = new SpecularChannelContainer {Color = float3.One, Shininess = 4}
            };
            var cubeMesh1 = SimpleMeshes.CreateCuboid(new float3(5, 5, 10));

            
            _cubeTransform2 = new TransformComponent {Scale = new float3(8, 8, 3), Translation = new float3(20, 0, 0)};
            var cubeMaterial2 = new MaterialComponent
            {
                Diffuse = new MatChannelContainer {Color = new float3(79, 201, 234)}, 
                Specular = new SpecularChannelContainer {Color = float3.One, Shininess = 4}
            };
            var cubeMesh2 = SimpleMeshes.CreateCuboid(new float3(3, 6, 3));
			
			_cubeTransform3 = new TransformComponent {Scale = new float3(5, 5, 5), Translation = new float3(20, 0, 0)};
            var cubeMaterial3 = new MaterialComponent
            {
                Diffuse = new MatChannelContainer {Color = new float3(70, 72, 130)}, 
                Specular = new SpecularChannelContainer {Color = float3.One, Shininess = 4}
            };
            var cubeMesh3 = SimpleMeshes.CreateCuboid(new float3(8, 6, 8));


    var cubeNode = new SceneNodeContainer();
cubeNode.Components = new List<SceneComponentContainer>();
cubeNode.Components.Add(_cubeTransform);
cubeNode.Components.Add(cubeMaterial);
cubeNode.Components.Add(cubeMesh);

    var cubeNode1 = new SceneNodeContainer();
cubeNode1.Components = new List<SceneComponentContainer>();
cubeNode1.Components.Add(_cubeTransform1);
cubeNode1.Components.Add(cubeMaterial1);
cubeNode1.Components.Add(cubeMesh1);
            
    var cubeNode2 = new SceneNodeContainer();
cubeNode2.Components = new List<SceneComponentContainer>();
cubeNode2.Components.Add(_cubeTransform2);
cubeNode2.Components.Add(cubeMaterial2);
cubeNode2.Components.Add(cubeMesh2);
    var cubeNode3 = new SceneNodeContainer();
cubeNode3.Components = new List<SceneComponentContainer>();
cubeNode3.Components.Add(_cubeTransform3);
cubeNode3.Components.Add(cubeMaterial3);
cubeNode3.Components.Add(cubeMesh3);

            _scene = new SceneContainer();
            _scene.Children = new List<SceneNodeContainer>();
            _scene.Children.Add(cubeNode);
            _scene.Children.Add(cubeNode1);
            _scene.Children.Add(cubeNode2);
			_scene.Children.Add(cubeNode3);

            
  _sceneRenderer = new SceneRenderer(_scene);
  }

        
  public override void RenderAFrame()
  {
            Diagnostics.Log(TimeSinceStart);

            
            RC.Clear(ClearFlags.Color | ClearFlags.Depth);

            
            _camAngle = _camAngle + 90.0f * M.Pi/180.0f * DeltaTime ;

            
    _cubeTransform.Translation = new float3(0, 5 * M.Sin(3 * TimeSinceStart), 0);

    _cubeTransform1.Rotation = new float3(0, 4 * M.Sin(6 * TimeSinceStart), 0);

    _cubeTransform2.Scale = new float3(M.Sin(TimeSinceStart) +3, M.Sin(TimeSinceStart) + 5, M.Sin(TimeSinceStart) + 1);
    
    _cubeTransform3.Scale = new float3(M.Sin(TimeSinceStart) +8, M.Sin(TimeSinceStart) + 10, M.Sin(TimeSinceStart) + 2);

            
    RC.View = float4x4.CreateTranslation(0, 0, 50) * float4x4.CreateRotationY(_camAngle);


    _sceneRenderer.Render(RC);

            
    Present();
    }


        
    public override void Resize()
        {
            
        RC.Viewport(0, 0, Width, Height);

            
        var aspectRatio = Width / (float)Height;

            
        var projection = float4x4.CreatePerspectiveFieldOfView(M.PiOver4, aspectRatio, 1, 20000);
        RC.Projection = projection;
        }
    }
}      