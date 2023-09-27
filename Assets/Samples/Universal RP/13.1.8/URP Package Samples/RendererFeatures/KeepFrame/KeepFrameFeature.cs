using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

//This renderer feature will replicate a "don't clear" behaviour by injecting two passes into the pipeline:
//One pass that copies color at the end of a frame
//Another pass that draws the content of the copied texture at the beginning of a new frame
public class KeepFrameFeature : ScriptableRendererFeature
{
    //This pass is responsible for copying color to a specified destination
    class CopyFramePass : ScriptableRenderPass
    {
        private RenderTargetIdentifier source { get; set; }
        [Obsolete]
        private RenderTargetHandle destination { get; set; }

        [Obsolete]
        public void Setup(RenderTargetIdentifier source, RenderTargetHandle destination)
        {
            this.source = source;
            this.destination = destination;
        }

        [Obsolete]
#pragma warning disable CS0809 // Устаревший член переопределяет неустаревший член
        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
#pragma warning restore CS0809 // Устаревший член переопределяет неустаревший член
        {
            if (renderingData.cameraData.camera.cameraType != CameraType.Game)
                return;

            CommandBuffer cmd = CommandBufferPool.Get("CopyFramePass");
            RenderTargetIdentifier opaqueColorRT = destination.Identifier();
            Blit(cmd, source, opaqueColorRT);
            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }

        [Obsolete]
#pragma warning disable CS0809 // Устаревший член переопределяет неустаревший член
        public override void OnCameraCleanup(CommandBuffer cmd)
#pragma warning restore CS0809 // Устаревший член переопределяет неустаревший член
        {
            cmd.ReleaseTemporaryRT(nameID: destination.id);

            if (destination != RenderTargetHandle.CameraTarget)
            {
                cmd.ReleaseTemporaryRT(destination.id);
                destination = RenderTargetHandle.CameraTarget;
            }
        }
    }

    //This pass is responsible for drawing the old color to a full screen quad
    class DrawOldFramePass : ScriptableRenderPass
    {
        private Material m_DrawOldFrameMaterial;
        [Obsolete]
        private RenderTargetHandle m_handle;
        private string m_textureName;

        [Obsolete]
        public void Setup(Material drawOldFrameMaterial, RenderTargetHandle handle, string textureName)
        {
            m_DrawOldFrameMaterial = drawOldFrameMaterial;
            m_handle = handle;
            m_textureName = textureName;
        }

        [Obsolete]
#pragma warning disable CS0809 // Устаревший член переопределяет неустаревший член
        public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescripor)
#pragma warning restore CS0809 // Устаревший член переопределяет неустаревший член
        {
            RenderTextureDescriptor descriptor = cameraTextureDescripor;
            descriptor.msaaSamples = 1;
            descriptor.depthBufferBits = 0;
            cmd.GetTemporaryRT(m_handle.id, descriptor, FilterMode.Bilinear);
        }

        [Obsolete]
#pragma warning disable CS0809 // Устаревший член переопределяет неустаревший член
        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
#pragma warning restore CS0809 // Устаревший член переопределяет неустаревший член
        {
            if (m_DrawOldFrameMaterial != null)
            {
                CommandBuffer cmd = CommandBufferPool.Get("DrawOldFramePass");
                cmd.SetGlobalTexture(m_textureName, m_handle.id);
                cmd.SetViewProjectionMatrices(Matrix4x4.identity, Matrix4x4.identity);
                cmd.DrawMesh(RenderingUtils.fullscreenMesh, Matrix4x4.identity, m_DrawOldFrameMaterial, 0, 0);
                cmd.SetViewProjectionMatrices(renderingData.cameraData.camera.worldToCameraMatrix, renderingData.cameraData.camera.projectionMatrix);
                context.ExecuteCommandBuffer(cmd);
                CommandBufferPool.Release(cmd);
            }
        }
    }

    [Serializable]
    public class Settings
    {
        [Tooltip("The material that is used when the old frame is redrawn at the start of the new frame (before opaques).")]
        public Material displayMaterial;
        [Tooltip("The name of the texture used for referencing the copied frame. (Defaults to _FrameCopyTex if empty)")]
        public string textureName;
    }

    private CopyFramePass m_CopyFrame;
    private DrawOldFramePass m_DrawOldFame;
    [Obsolete]
    private RenderTargetHandle m_OldFrameHandle;

    public Settings settings = new Settings();

    //In this function the passes are created and their point of injection is set
    public override void Create()
    {
        m_CopyFrame = new CopyFramePass();
        m_CopyFrame.renderPassEvent = RenderPassEvent.AfterRenderingTransparents; //Frame color is copied late in the frame

        m_DrawOldFame = new DrawOldFramePass();
        m_DrawOldFame.renderPassEvent = RenderPassEvent.BeforeRenderingOpaques; //Old frame is drawn early in the frame
    }

    [Obsolete]
#pragma warning disable CS0809 // Устаревший член переопределяет неустаревший член
    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
#pragma warning restore CS0809 // Устаревший член переопределяет неустаревший член
    {
        m_OldFrameHandle.Init("_OldFrameRenderTarget");
        m_DrawOldFame.ConfigureClear(ClearFlag.None, Color.red);

        m_CopyFrame.Setup(renderer.cameraColorTarget, m_OldFrameHandle);
        renderer.EnqueuePass(m_CopyFrame);

        m_DrawOldFame.Setup(settings.displayMaterial, m_OldFrameHandle, String.IsNullOrEmpty(settings.textureName) ? "_FrameCopyTex" : settings.textureName);
        renderer.EnqueuePass(m_DrawOldFame);
    }
}
