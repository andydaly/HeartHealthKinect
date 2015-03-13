using UnityEngine;
using System.Collections;
using Windows.Kinect;
using System.Runtime.InteropServices;
using Microsoft.Kinect.Face;
using System.Collections.Generic;
using System;

public class Kinect2Interface : DepthSensorInterface
{
	private KinectInterop.FrameSource sensorFlags;
	private KinectSensor kinectSensor;
	private CoordinateMapper coordMapper;
	
	private BodyFrameReader bodyFrameReader;
	private BodyIndexFrameReader bodyIndexFrameReader;
	private ColorFrameReader colorFrameReader;
	private DepthFrameReader depthFrameReader;
	private InfraredFrameReader infraredFrameReader;
	
	private MultiSourceFrameReader multiSourceFrameReader;
	private MultiSourceFrame multiSourceFrame;

	private int bodyCount;
	private Body[] bodyData;

	private bool bFaceTrackingInited = false;
	private FaceFrameSource[] faceFrameSources = null;
	private FaceFrameReader[] faceFrameReaders = null;
	private FaceFrameResult[] faceFrameResults = null;

//	private int faceDisplayWidth;
//	private int faceDisplayHeight;

	private bool isDrawFaceRect = false;
	private HighDefinitionFaceFrameSource[] hdFaceFrameSources = null;
	private HighDefinitionFaceFrameReader[] hdFaceFrameReaders = null;
	private FaceAlignment[] hdFaceAlignments = null;
	private FaceModel[] hdFaceModels = null;


	public bool InitSensorInterface (ref bool bNeedRestart)
	{
		bool bOneCopied = false, bAllCopied = true;

		if(!KinectInterop.Is64bitArchitecture())
		{
			Debug.Log("x32-architecture detected.");
			KinectInterop.CopyResourceFile("KinectUnityAddin.dll", "KinectUnityAddin.dll", ref bOneCopied, ref bAllCopied);
		}
		else
		{
			Debug.Log("x64-architecture detected.");
			KinectInterop.CopyResourceFile("KinectUnityAddin.dll", "KinectUnityAddin.dll.x64", ref bOneCopied, ref bAllCopied);
		}

		bNeedRestart = (bOneCopied && bAllCopied);

		return true;
	}

	public void FreeSensorInterface ()
	{
	}

	public int GetSensorsCount()
	{
		int numSensors = KinectSensor.GetDefault() != null ? 1 : 0;
		return numSensors;
	}

	public KinectInterop.SensorData OpenDefaultSensor (KinectInterop.FrameSource dwFlags, float sensorAngle, bool bUseMultiSource)
	{
		KinectInterop.SensorData sensorData = new KinectInterop.SensorData();
		//sensorFlags = dwFlags;
		
		kinectSensor = KinectSensor.GetDefault();
		if(kinectSensor == null)
			return null;
		
		coordMapper = kinectSensor.CoordinateMapper;

		this.bodyCount = kinectSensor.BodyFrameSource.BodyCount;
		sensorData.bodyCount = this.bodyCount;
		sensorData.jointCount = 25;
		
		if((dwFlags & KinectInterop.FrameSource.TypeBody) != 0)
		{
			if(!bUseMultiSource)
				bodyFrameReader = kinectSensor.BodyFrameSource.OpenReader();
			
			bodyData = new Body[sensorData.bodyCount];
		}
		
		var frameDesc = kinectSensor.ColorFrameSource.CreateFrameDescription(ColorImageFormat.Rgba);
		sensorData.colorImageWidth = frameDesc.Width;
		sensorData.colorImageHeight = frameDesc.Height;
		
		if((dwFlags & KinectInterop.FrameSource.TypeColor) != 0)
		{
			if(!bUseMultiSource)
				colorFrameReader = kinectSensor.ColorFrameSource.OpenReader();
			
			sensorData.colorImage = new byte[frameDesc.BytesPerPixel * frameDesc.LengthInPixels];
		}
		
		sensorData.depthImageWidth = kinectSensor.DepthFrameSource.FrameDescription.Width;
		sensorData.depthImageHeight = kinectSensor.DepthFrameSource.FrameDescription.Height;
		
		if((dwFlags & KinectInterop.FrameSource.TypeDepth) != 0)
		{
			if(!bUseMultiSource)
				depthFrameReader = kinectSensor.DepthFrameSource.OpenReader();
			
			sensorData.depthImage = new ushort[kinectSensor.DepthFrameSource.FrameDescription.LengthInPixels];
		}
		
		if((dwFlags & KinectInterop.FrameSource.TypeBodyIndex) != 0)
		{
			if(!bUseMultiSource)
				bodyIndexFrameReader = kinectSensor.BodyIndexFrameSource.OpenReader();
			
			sensorData.bodyIndexImage = new byte[kinectSensor.BodyIndexFrameSource.FrameDescription.LengthInPixels];
		}
		
		if((dwFlags & KinectInterop.FrameSource.TypeInfrared) != 0)
		{
			if(!bUseMultiSource)
				infraredFrameReader = kinectSensor.InfraredFrameSource.OpenReader();
			
			sensorData.infraredImage = new ushort[kinectSensor.InfraredFrameSource.FrameDescription.LengthInPixels];
		}
		
		if(!kinectSensor.IsOpen)
		{
			kinectSensor.Open();
		}
		
		if(bUseMultiSource && dwFlags != KinectInterop.FrameSource.TypeNone && kinectSensor.IsOpen)
		{
			multiSourceFrameReader = kinectSensor.OpenMultiSourceFrameReader((FrameSourceTypes)dwFlags);
		}
		
		return sensorData;
	}

	public void CloseSensor (KinectInterop.SensorData sensorData)
	{
		if(coordMapper != null)
		{
			coordMapper = null;
		}
		
		if(bodyFrameReader != null)
		{
			bodyFrameReader.Dispose();
			bodyFrameReader = null;
		}
		
		if(bodyIndexFrameReader != null)
		{
			bodyIndexFrameReader.Dispose();
			bodyIndexFrameReader = null;
		}
		
		if(colorFrameReader != null)
		{
			colorFrameReader.Dispose();
			colorFrameReader = null;
		}
		
		if(depthFrameReader != null)
		{
			depthFrameReader.Dispose();
			depthFrameReader = null;
		}
		
		if(infraredFrameReader != null)
		{
			infraredFrameReader.Dispose();
			infraredFrameReader = null;
		}
		
		if(multiSourceFrameReader != null)
		{
			multiSourceFrameReader.Dispose();
			multiSourceFrameReader = null;
		}
		
		if(kinectSensor != null)
		{
			if (kinectSensor.IsOpen)
			{
				kinectSensor.Close();
			}
			
			kinectSensor = null;
		}
	}

	public bool UpdateSensorData (KinectInterop.SensorData sensorData)
	{
		return true;
	}

	public bool GetMultiSourceFrame (KinectInterop.SensorData sensorData)
	{
		if(multiSourceFrameReader != null)
		{
			multiSourceFrame = multiSourceFrameReader.AcquireLatestFrame();
			return (multiSourceFrame != null);
		}
		
		return false;
	}

	public void FreeMultiSourceFrame (KinectInterop.SensorData sensorData)
	{
		if(multiSourceFrame != null)
		{
			multiSourceFrame = null;
		}
	}

	public bool PollBodyFrame (KinectInterop.SensorData sensorData, ref KinectInterop.BodyFrameData bodyFrame, ref Matrix4x4 kinectToWorld)
	{
		bool bNewFrame = false;
		
		if((multiSourceFrameReader != null && multiSourceFrame != null) || 
		   bodyFrameReader != null)
		{
			var frame = multiSourceFrame != null ? multiSourceFrame.BodyFrameReference.AcquireFrame() :
				bodyFrameReader.AcquireLatestFrame();
			
			if(frame != null)
			{
				frame.GetAndRefreshBodyData(bodyData);
				bodyFrame.liRelativeTime = frame.RelativeTime.Ticks;
				
				frame.Dispose();
				frame = null;
				
				for(int i = 0; i < sensorData.bodyCount; i++)
				{
					Body body = bodyData[i];
					
					if (body == null)
					{
						bodyFrame.bodyData[i].bIsTracked = 0;
						continue;
					}
					
					bodyFrame.bodyData[i].bIsTracked = (short)(body.IsTracked ? 1 : 0);
					
					if(body.IsTracked)
					{
						// transfer body and joints data
						bodyFrame.bodyData[i].liTrackingID = (long)body.TrackingId;
						
						for(int j = 0; j < sensorData.jointCount; j++)
						{
							Windows.Kinect.Joint joint = body.Joints[(Windows.Kinect.JointType)j];
							KinectInterop.JointData jointData = bodyFrame.bodyData[i].joint[j];
							
							jointData.jointType = (KinectInterop.JointType)j;
							jointData.trackingState = (KinectInterop.TrackingState)joint.TrackingState;

							if((int)joint.TrackingState != (int)TrackingState.NotTracked)
							{
								jointData.kinectPos = new Vector3(joint.Position.X, joint.Position.Y, joint.Position.Z);
								jointData.position = kinectToWorld.MultiplyPoint3x4(jointData.kinectPos);
							}
							
							jointData.orientation = Quaternion.identity;
//							Windows.Kinect.Vector4 vQ = body.JointOrientations[jointData.jointType].Orientation;
//							jointData.orientation = new Quaternion(vQ.X, vQ.Y, vQ.Z, vQ.W);
							
							if(j == 0)
							{
								bodyFrame.bodyData[i].position = jointData.position;
								bodyFrame.bodyData[i].orientation = jointData.orientation;
							}
							
							bodyFrame.bodyData[i].joint[j] = jointData;
						}

						// tranfer hand states
						bodyFrame.bodyData[i].leftHandState = (KinectInterop.HandState)body.HandLeftState;
						bodyFrame.bodyData[i].leftHandConfidence = (KinectInterop.TrackingConfidence)body.HandLeftConfidence;
						
						bodyFrame.bodyData[i].rightHandState = (KinectInterop.HandState)body.HandRightState;
						bodyFrame.bodyData[i].rightHandConfidence = (KinectInterop.TrackingConfidence)body.HandRightConfidence;
					}
				}
				
				bNewFrame = true;
			}
		}
		
		return bNewFrame;
	}

	public bool PollColorFrame (KinectInterop.SensorData sensorData)
	{
		bool bNewFrame = false;
		
		if((multiSourceFrameReader != null && multiSourceFrame != null) ||
		   colorFrameReader != null) 
		{
			var colorFrame = multiSourceFrame != null ? multiSourceFrame.ColorFrameReference.AcquireFrame() :
				colorFrameReader.AcquireLatestFrame();
			
			if(colorFrame != null)
			{
				var pColorData = GCHandle.Alloc(sensorData.colorImage, GCHandleType.Pinned);
				colorFrame.CopyConvertedFrameDataToIntPtr(pColorData.AddrOfPinnedObject(), (uint)sensorData.colorImage.Length, ColorImageFormat.Rgba);
				pColorData.Free();

				sensorData.lastColorFrameTime = colorFrame.RelativeTime.Ticks;
				
				colorFrame.Dispose();
				colorFrame = null;
				
				bNewFrame = true;
			}
		}
		
		return bNewFrame;
	}

	public bool PollDepthFrame (KinectInterop.SensorData sensorData)
	{
		bool bNewFrame = false;
		
		if((multiSourceFrameReader != null && multiSourceFrame != null) ||
		   depthFrameReader != null)
		{
			var depthFrame = multiSourceFrame != null ? multiSourceFrame.DepthFrameReference.AcquireFrame() :
				depthFrameReader.AcquireLatestFrame();
			
			if(depthFrame != null)
			{
				var pDepthData = GCHandle.Alloc(sensorData.depthImage, GCHandleType.Pinned);
				depthFrame.CopyFrameDataToIntPtr(pDepthData.AddrOfPinnedObject(), (uint)sensorData.depthImage.Length * sizeof(ushort));
				pDepthData.Free();
				
				sensorData.lastDepthFrameTime = depthFrame.RelativeTime.Ticks;
				
				depthFrame.Dispose();
				depthFrame = null;
				
				bNewFrame = true;
			}
			
			if((multiSourceFrameReader != null && multiSourceFrame != null) ||
			   bodyIndexFrameReader != null)
			{
				var bodyIndexFrame = multiSourceFrame != null ? multiSourceFrame.BodyIndexFrameReference.AcquireFrame() :
					bodyIndexFrameReader.AcquireLatestFrame();
				
				if(bodyIndexFrame != null)
				{
					var pBodyIndexData = GCHandle.Alloc(sensorData.bodyIndexImage, GCHandleType.Pinned);
					bodyIndexFrame.CopyFrameDataToIntPtr(pBodyIndexData.AddrOfPinnedObject(), (uint)sensorData.bodyIndexImage.Length);
					pBodyIndexData.Free();
					
					sensorData.lastBodyIndexFrameTime = bodyIndexFrame.RelativeTime.Ticks;
					
					bodyIndexFrame.Dispose();
					bodyIndexFrame = null;
					
					bNewFrame = true;
				}
			}
		}
		
		return bNewFrame;
	}

	public bool PollInfraredFrame (KinectInterop.SensorData sensorData)
	{
		bool bNewFrame = false;
		
		if((multiSourceFrameReader != null && multiSourceFrame != null) ||
		   infraredFrameReader != null)
		{
			var infraredFrame = multiSourceFrame != null ? multiSourceFrame.InfraredFrameReference.AcquireFrame() :
				infraredFrameReader.AcquireLatestFrame();
			
			if(infraredFrame != null)
			{
				var pInfraredData = GCHandle.Alloc(sensorData.infraredImage, GCHandleType.Pinned);
				infraredFrame.CopyFrameDataToIntPtr(pInfraredData.AddrOfPinnedObject(), (uint)sensorData.infraredImage.Length * sizeof(ushort));
				pInfraredData.Free();
				
				sensorData.lastInfraredFrameTime = infraredFrame.RelativeTime.Ticks;
				
				infraredFrame.Dispose();
				infraredFrame = null;
				
				bNewFrame = true;
			}
		}
		
		return bNewFrame;
	}

	public void FixJointOrientations(KinectInterop.SensorData sensorData, ref KinectInterop.BodyData bodyData)
	{
		// no fixes are needed
	}

	public Vector2 MapSpacePointToDepthCoords (KinectInterop.SensorData sensorData, Vector3 spacePos)
	{
		Vector2 vPoint = Vector2.zero;
		
		if(coordMapper != null)
		{
			CameraSpacePoint camPoint = new CameraSpacePoint();
			camPoint.X = spacePos.x;
			camPoint.Y = spacePos.y;
			camPoint.Z = spacePos.z;
			
			CameraSpacePoint[] camPoints = new CameraSpacePoint[1];
			camPoints[0] = camPoint;
			
			DepthSpacePoint[] depthPoints = new DepthSpacePoint[1];
			coordMapper.MapCameraPointsToDepthSpace(camPoints, depthPoints);
			
			DepthSpacePoint depthPoint = depthPoints[0];
			
			if(depthPoint.X >= 0 && depthPoint.X < sensorData.depthImageWidth &&
			   depthPoint.Y >= 0 && depthPoint.Y < sensorData.depthImageHeight)
			{
				vPoint.x = depthPoint.X;
				vPoint.y = depthPoint.Y;
			}
		}
		
		return vPoint;
	}

	public Vector3 MapDepthPointToSpaceCoords (KinectInterop.SensorData sensorData, Vector2 depthPos, ushort depthVal)
	{
		Vector3 vPoint = Vector3.zero;
		
		if(coordMapper != null && depthPos != Vector2.zero)
		{
			DepthSpacePoint depthPoint = new DepthSpacePoint();
			depthPoint.X = depthPos.x;
			depthPoint.Y = depthPos.y;
			
			DepthSpacePoint[] depthPoints = new DepthSpacePoint[1];
			depthPoints[0] = depthPoint;
			
			ushort[] depthVals = new ushort[1];
			depthVals[0] = depthVal;
			
			CameraSpacePoint[] camPoints = new CameraSpacePoint[1];
			coordMapper.MapDepthPointsToCameraSpace(depthPoints, depthVals, camPoints);
			
			CameraSpacePoint camPoint = camPoints[0];
			vPoint.x = camPoint.X;
			vPoint.y = camPoint.Y;
			vPoint.z = camPoint.Z;
		}
		
		return vPoint;
	}

	public Vector2 MapDepthPointToColorCoords (KinectInterop.SensorData sensorData, Vector2 depthPos, ushort depthVal)
	{
		Vector2 vPoint = Vector2.zero;
		
		if(coordMapper != null && depthPos != Vector2.zero)
		{
			DepthSpacePoint depthPoint = new DepthSpacePoint();
			depthPoint.X = depthPos.x;
			depthPoint.Y = depthPos.y;
			
			DepthSpacePoint[] depthPoints = new DepthSpacePoint[1];
			depthPoints[0] = depthPoint;
			
			ushort[] depthVals = new ushort[1];
			depthVals[0] = depthVal;
			
			ColorSpacePoint[] colPoints = new ColorSpacePoint[1];
			coordMapper.MapDepthPointsToColorSpace(depthPoints, depthVals, colPoints);
			
			ColorSpacePoint colPoint = colPoints[0];
			vPoint.x = colPoint.X;
			vPoint.y = colPoint.Y;
		}
		
		return vPoint;
	}

	public bool MapDepthFrameToColorCoords (KinectInterop.SensorData sensorData, ref Vector2[] vColorCoords)
	{
		if(coordMapper != null && sensorData.colorImage != null && sensorData.depthImage != null)
		{
			var pDepthData = GCHandle.Alloc(sensorData.depthImage, GCHandleType.Pinned);
			var pColorCoordinatesData = GCHandle.Alloc(vColorCoords, GCHandleType.Pinned);
			
			coordMapper.MapDepthFrameToColorSpaceUsingIntPtr(
				pDepthData.AddrOfPinnedObject(), 
				sensorData.depthImage.Length * sizeof(ushort),
				pColorCoordinatesData.AddrOfPinnedObject(), 
				(uint)vColorCoords.Length);
			
			pColorCoordinatesData.Free();
			pDepthData.Free();
			
			return true;
		}
		
		return false;
	}

	// returns the index of the given joint in joint's array or -1 if joint is not applicable
	public int GetJointIndex(KinectInterop.JointType joint)
	{
		return (int)joint;
	}
	
	// returns the joint at given index
	public KinectInterop.JointType GetJointAtIndex(int index)
	{
		return (KinectInterop.JointType)(index);
	}
	
	// returns the parent joint of the given joint
	public KinectInterop.JointType GetParentJoint(KinectInterop.JointType joint)
	{
		switch(joint)
		{
			case KinectInterop.JointType.SpineBase:
				return KinectInterop.JointType.SpineBase;
				
			case KinectInterop.JointType.Neck:
				return KinectInterop.JointType.SpineShoulder;
				
			case KinectInterop.JointType.SpineShoulder:
				return KinectInterop.JointType.SpineMid;
				
			case KinectInterop.JointType.ShoulderLeft:
			case KinectInterop.JointType.ShoulderRight:
				return KinectInterop.JointType.SpineShoulder;
				
			case KinectInterop.JointType.HipLeft:
			case KinectInterop.JointType.HipRight:
				return KinectInterop.JointType.SpineBase;
				
			case KinectInterop.JointType.HandTipLeft:
				return KinectInterop.JointType.HandLeft;
				
			case KinectInterop.JointType.ThumbLeft:
				return KinectInterop.JointType.WristLeft;
			
			case KinectInterop.JointType.HandTipRight:
				return KinectInterop.JointType.HandRight;

			case KinectInterop.JointType.ThumbRight:
				return KinectInterop.JointType.WristRight;
		}
			
			return (KinectInterop.JointType)((int)joint - 1);
	}
	
	// returns the next joint in the hierarchy, as to the given joint
	public KinectInterop.JointType GetNextJoint(KinectInterop.JointType joint)
	{
		switch(joint)
		{
			case KinectInterop.JointType.SpineBase:
				return KinectInterop.JointType.SpineMid;
			case KinectInterop.JointType.SpineMid:
				return KinectInterop.JointType.SpineShoulder;
			case KinectInterop.JointType.SpineShoulder:
				return KinectInterop.JointType.Neck;
			case KinectInterop.JointType.Neck:
				return KinectInterop.JointType.Head;
				
			case KinectInterop.JointType.ShoulderLeft:
				return KinectInterop.JointType.ElbowLeft;
			case KinectInterop.JointType.ElbowLeft:
				return KinectInterop.JointType.WristLeft;
			case KinectInterop.JointType.WristLeft:
				return KinectInterop.JointType.HandLeft;
			case KinectInterop.JointType.HandLeft:
				return KinectInterop.JointType.HandTipLeft;
				
			case KinectInterop.JointType.ShoulderRight:
				return KinectInterop.JointType.ElbowRight;
			case KinectInterop.JointType.ElbowRight:
				return KinectInterop.JointType.WristRight;
			case KinectInterop.JointType.WristRight:
				return KinectInterop.JointType.HandRight;
			case KinectInterop.JointType.HandRight:
				return KinectInterop.JointType.HandTipRight;
				
			case KinectInterop.JointType.HipLeft:
				return KinectInterop.JointType.KneeLeft;
			case KinectInterop.JointType.KneeLeft:
				return KinectInterop.JointType.AnkleLeft;
			case KinectInterop.JointType.AnkleLeft:
				return KinectInterop.JointType.FootLeft;
				
			case KinectInterop.JointType.HipRight:
				return KinectInterop.JointType.KneeRight;
			case KinectInterop.JointType.KneeRight:
				return KinectInterop.JointType.AnkleRight;
			case KinectInterop.JointType.AnkleRight:
				return KinectInterop.JointType.FootRight;
		}
		
		return joint;  // in case of end joint - Head, HandTipLeft, HandTipRight, FootLeft, FootRight
	}
	
	public bool IsFaceTrackingAvailable(ref bool bNeedRestart)
	{
		bool bOneCopied = false, bAllCopied = true;

		if(!KinectInterop.Is64bitArchitecture())
		{
			// 32 bit
			//Debug.Log("Face - x32-architecture.");

			KinectInterop.CopyResourceFile("Kinect20.Face.dll", "Kinect20.Face.dll", ref bOneCopied, ref bAllCopied);
			KinectInterop.CopyResourceFile("KinectFaceUnityAddin.dll", "KinectFaceUnityAddin.dll", ref bOneCopied, ref bAllCopied);
		}
		else
		{
			// 64 bit
			//Debug.Log("Face - x64-architecture.");

			KinectInterop.CopyResourceFile("Kinect20.Face.dll", "Kinect20.Face.dll.x64", ref bOneCopied, ref bAllCopied);
			KinectInterop.CopyResourceFile("KinectFaceUnityAddin.dll", "KinectFaceUnityAddin.dll.x64", ref bOneCopied, ref bAllCopied);
		}

		KinectInterop.UnzipResourceDirectory(".", "NuiDatabase.zip", "./NuiDatabase");
		
		bNeedRestart = (bOneCopied && bAllCopied);
		
		return true;
	}
	
	public bool InitFaceTracking(bool bUseFaceModel, bool bDrawFaceRect)
	{
		isDrawFaceRect = bDrawFaceRect;

		// specify the required face frame results
		FaceFrameFeatures faceFrameFeatures =
			FaceFrameFeatures.BoundingBoxInColorSpace
				//| FaceFrameFeatures.BoundingBoxInInfraredSpace
				//| FaceFrameFeatures.PointsInColorSpace
				//| FaceFrameFeatures.PointsInInfraredSpace
				| FaceFrameFeatures.RotationOrientation
				| FaceFrameFeatures.FaceEngagement
				//| FaceFrameFeatures.Glasses
				//| FaceFrameFeatures.Happy
				//| FaceFrameFeatures.LeftEyeClosed
				//| FaceFrameFeatures.RightEyeClosed
				| FaceFrameFeatures.LookingAway
				//| FaceFrameFeatures.MouthMoved
				//| FaceFrameFeatures.MouthOpen
				;
		
		// create a face frame source + reader to track each face in the FOV
		faceFrameSources = new FaceFrameSource[this.bodyCount];
		faceFrameReaders = new FaceFrameReader[this.bodyCount];

		if(bUseFaceModel)
		{
			hdFaceFrameSources = new HighDefinitionFaceFrameSource[this.bodyCount];
			hdFaceFrameReaders = new HighDefinitionFaceFrameReader[this.bodyCount];

			hdFaceModels = new FaceModel[this.bodyCount];
			hdFaceAlignments = new FaceAlignment[this.bodyCount];
		}

		for (int i = 0; i < bodyCount; i++)
		{
			// create the face frame source with the required face frame features and an initial tracking Id of 0
			faceFrameSources[i] = FaceFrameSource.Create(this.kinectSensor, 0, faceFrameFeatures);
			
			// open the corresponding reader
			faceFrameReaders[i] = faceFrameSources[i].OpenReader();

			if(bUseFaceModel)
			{
				///////// HD Face
				hdFaceFrameSources[i] = HighDefinitionFaceFrameSource.Create(this.kinectSensor);
				hdFaceFrameReaders[i] = hdFaceFrameSources[i].OpenReader();

				hdFaceModels[i] = FaceModel.Create();
				hdFaceAlignments[i] = FaceAlignment.Create();
			}
		}
		
		// allocate storage to store face frame results for each face in the FOV
		faceFrameResults = new FaceFrameResult[this.bodyCount];

//		FrameDescription frameDescription = this.kinectSensor.ColorFrameSource.FrameDescription;
//		faceDisplayWidth = frameDescription.Width;
//		faceDisplayHeight = frameDescription.Height;

		bFaceTrackingInited = true;

		return bFaceTrackingInited;
	}
	
	public void FinishFaceTracking()
	{
		if(faceFrameReaders != null)
		{
			for (int i = 0; i < faceFrameReaders.Length; i++)
			{
				if (faceFrameReaders[i] != null)
				{
					faceFrameReaders[i].Dispose();
					faceFrameReaders[i] = null;
				}
			}
		}

		if(faceFrameSources != null)
		{
			for (int i = 0; i < faceFrameSources.Length; i++)
			{
				faceFrameSources[i] = null;
			}
		}

		///////// HD Face
		if(hdFaceFrameSources != null)
		{
			for (int i = 0; i < hdFaceAlignments.Length; i++)
			{
				hdFaceAlignments[i] = null;
			}

			for (int i = 0; i < hdFaceModels.Length; i++)
			{
				if (hdFaceModels[i] != null)
				{
					hdFaceModels[i].Dispose();
					hdFaceModels[i] = null;
				}
			}
			
			for (int i = 0; i < hdFaceFrameReaders.Length; i++)
			{
				if (hdFaceFrameReaders[i] != null)
				{
					hdFaceFrameReaders[i].Dispose();
					hdFaceFrameReaders[i] = null;
				}
			}

			for (int i = 0; i < hdFaceFrameSources.Length; i++)
			{
				hdFaceFrameSources[i] = null;
			}
		}

		bFaceTrackingInited = false;
	}
	
	public bool UpdateFaceTracking()
	{
		if(bodyData == null || faceFrameSources == null || faceFrameReaders == null)
			return false;

		for(int i = 0; i < this.bodyCount; i++)
		{
			if(faceFrameSources[i] != null)
			{
				if(!faceFrameSources[i].IsTrackingIdValid)
				{
					faceFrameSources[i].TrackingId = 0;
				}
				
				if(bodyData[i] != null && bodyData[i].IsTracked)
				{
					faceFrameSources[i].TrackingId = bodyData[i].TrackingId;
				}
			}

			if (faceFrameReaders[i] != null) 
			{
				FaceFrame faceFrame = faceFrameReaders[i].AcquireLatestFrame();
				
				if (faceFrame != null)
				{
					int index = GetFaceSourceIndex(faceFrame.FaceFrameSource);
					
					if(ValidateFaceBox(faceFrame.FaceFrameResult))
					{
						faceFrameResults[index] = faceFrame.FaceFrameResult;
					}
					else
					{
						faceFrameResults[index] = null;
					}
					
					faceFrame.Dispose();
					faceFrame = null;
				}
			}

			///////// HD Face
			if(hdFaceFrameSources != null && hdFaceFrameSources[i] != null)
			{
				if(!hdFaceFrameSources[i].IsTrackingIdValid)
				{
					hdFaceFrameSources[i].TrackingId = 0;
				}

				if(bodyData[i] != null && bodyData[i].IsTracked)
				{
					hdFaceFrameSources[i].TrackingId = bodyData[i].TrackingId;
				}
			}
			
			if(hdFaceFrameReaders != null && hdFaceFrameReaders[i] != null)
			{
				HighDefinitionFaceFrame hdFaceFrame = hdFaceFrameReaders[i].AcquireLatestFrame();
				
				if(hdFaceFrame != null)
				{
					if(hdFaceFrame.IsFaceTracked && (hdFaceAlignments[i] != null))
					{
						hdFaceFrame.GetAndRefreshFaceAlignmentResult(hdFaceAlignments[i]);
					}
					
					hdFaceFrame.Dispose();
					hdFaceFrame = null;
				}
			}

		}

		return true;
	}
	
	private int GetFaceSourceIndex(FaceFrameSource faceFrameSource)
	{
		int index = -1;
		
		for (int i = 0; i < this.bodyCount; i++)
		{
			if (this.faceFrameSources[i] == faceFrameSource)
			{
				index = i;
				break;
			}
		}
		
		return index;
	}
	
	private bool ValidateFaceBox(FaceFrameResult faceResult)
	{
		bool isFaceValid = faceResult != null;
		
		if (isFaceValid)
		{
			var faceBox = faceResult.FaceBoundingBoxInColorSpace;
			//if (faceBox != null)
			{
				// check if we have a valid rectangle within the bounds of the screen space
				isFaceValid = (faceBox.Right - faceBox.Left) > 0 &&
					(faceBox.Bottom - faceBox.Top) > 0; // &&
						//faceBox.Right <= this.faceDisplayWidth &&
						//faceBox.Bottom <= this.faceDisplayHeight;
			}
		}
		
		return isFaceValid;
	}
	
	public bool IsFaceTrackingInitialized()
	{
		return bFaceTrackingInited;
	}
	
	public bool IsDrawFaceRect()
	{
		return isDrawFaceRect;
	}
	
	public bool IsFaceTracked(long userId)
	{
		for (int i = 0; i < this.bodyCount; i++)
		{
			if(faceFrameSources != null && faceFrameSources[i] != null && faceFrameSources[i].TrackingId == (ulong)userId)
			{
				if(faceFrameResults != null && faceFrameResults[i] != null)
				{
					return true;
				}
			}
		}

		return false;
	}

	public bool GetFaceRect(long userId, ref Rect faceRect)
	{
		for (int i = 0; i < this.bodyCount; i++)
		{
			if(faceFrameSources != null && faceFrameSources[i] != null && faceFrameSources[i].TrackingId == (ulong)userId)
			{
				if(faceFrameResults != null && faceFrameResults[i] != null)
				{
					var faceBox = faceFrameResults[i].FaceBoundingBoxInColorSpace;

					//if (faceBox != null)
					{
						faceRect.x = faceBox.Left;
						faceRect.y = faceBox.Top;
						faceRect.width = faceBox.Right - faceBox.Left;
						faceRect.height = faceBox.Bottom - faceBox.Top;
						
						return true;
					}
				}
			}
		}
		
		return false;
	}
	
	public void VisualizeFaceTrackerOnColorTex(Texture2D texColor)
	{
		if(bFaceTrackingInited)
		{
			for (int i = 0; i < this.bodyCount; i++)
			{
				if(faceFrameSources != null && faceFrameSources[i] != null && faceFrameSources[i].IsTrackingIdValid)
				{
					if(faceFrameResults != null && faceFrameResults[i] != null)
					{
						var faceBox = faceFrameResults[i].FaceBoundingBoxInColorSpace;
						
						//if (faceBox != null)
						{
							UnityEngine.Color color = UnityEngine.Color.magenta;
							Vector2 pt1, pt2;
							
							// bottom
							pt1.x = faceBox.Left; pt1.y = faceBox.Top;
							pt2.x = faceBox.Right; pt2.y = pt1.y;
							DrawLine(texColor, pt1, pt2, color);
							
							// right
							pt1.x = pt2.x; pt1.y = pt2.y;
							pt2.x = pt1.x; pt2.y = faceBox.Bottom;
							DrawLine(texColor, pt1, pt2, color);
							
							// top
							pt1.x = pt2.x; pt1.y = pt2.y;
							pt2.x = faceBox.Left; pt2.y = pt1.y;
							DrawLine(texColor, pt1, pt2, color);
							
							// left
							pt1.x = pt2.x; pt1.y = pt2.y;
							pt2.x = pt1.x; pt2.y = faceBox.Top;
							DrawLine(texColor, pt1, pt2, color);
						}
					}
				}
			}
		}
	}
	
	private void DrawLine(Texture2D a_Texture, Vector2 ptStart, Vector2 ptEnd, UnityEngine.Color a_Color)
	{
		KinectInterop.DrawLine(a_Texture, (int)ptStart.x, (int)ptStart.y, (int)ptEnd.x, (int)ptEnd.y, a_Color);
	}
	
	public bool GetHeadPosition(long userId, ref Vector3 headPos)
	{
		for (int i = 0; i < this.bodyCount; i++)
		{
			if(bodyData[i].TrackingId == (ulong)userId && bodyData[i].IsTracked)
			{
				CameraSpacePoint vHeadPos = bodyData[i].Joints[Windows.Kinect.JointType.Head].Position;

				headPos.x = vHeadPos.X;
				headPos.y = vHeadPos.Y;
				headPos.z = vHeadPos.Z;

				return true;
			}
		}
		
		return false;
	}
	
	public bool GetHeadRotation(long userId, ref Quaternion headRot)
	{
		for (int i = 0; i < this.bodyCount; i++)
		{
			if(faceFrameSources != null && faceFrameSources[i] != null && faceFrameSources[i].TrackingId == (ulong)userId)
			{
				if(faceFrameResults != null && faceFrameResults[i] != null)
				{
					Windows.Kinect.Vector4 vHeadRot = faceFrameResults[i].FaceRotationQuaternion;
					headRot = new Quaternion(vHeadRot.X, vHeadRot.Y, vHeadRot.Z, vHeadRot.W);

					return true;
				}
			}
		}
		
		return false;
	}
	
	public bool GetAnimUnits(long userId, ref Dictionary<KinectInterop.FaceShapeAnimations, float> dictAU)
	{
		for (int i = 0; i < this.bodyCount; i++)
		{
			if(hdFaceFrameSources != null && hdFaceFrameSources[i] != null && hdFaceFrameSources[i].TrackingId == (ulong)userId)
			{
				if(hdFaceAlignments != null && hdFaceAlignments[i] != null)
				{
					foreach(Microsoft.Kinect.Face.FaceShapeAnimations akey in hdFaceAlignments[i].AnimationUnits.Keys)
					{
						dictAU[(KinectInterop.FaceShapeAnimations)akey] = hdFaceAlignments[i].AnimationUnits[akey];
					}

					return true;
				}
			}
		}
		
		return false;
	}
	
	public bool GetShapeUnits(long userId, ref Dictionary<KinectInterop.FaceShapeDeformations, float> dictSU)
	{
		for (int i = 0; i < this.bodyCount; i++)
		{
			if(hdFaceFrameSources != null && hdFaceFrameSources[i] != null && hdFaceFrameSources[i].TrackingId == (ulong)userId)
			{
				if(hdFaceModels != null && hdFaceModels[i] != null)
				{
					foreach(Microsoft.Kinect.Face.FaceShapeDeformations skey in hdFaceModels[i].FaceShapeDeformations.Keys)
					{
						dictSU[(KinectInterop.FaceShapeDeformations)skey] = hdFaceModels[i].FaceShapeDeformations[skey];
					}
					
					return true;
				}
			}
		}
		
		return false;
	}
	
	public int GetFaceModelVerticesCount(long userId)
	{
		for (int i = 0; i < this.bodyCount; i++)
		{
			if(hdFaceFrameSources != null && hdFaceFrameSources[i] != null && (hdFaceFrameSources[i].TrackingId == (ulong)userId || userId == 0))
			{
				if(hdFaceModels != null && hdFaceModels[i] != null)
				{
					var vertices = hdFaceModels[i].CalculateVerticesForAlignment(hdFaceAlignments[i]);
					int verticesCount = vertices.Count;

					return verticesCount;
				}
			}
		}
		
		return 0;
	}
	
	public bool GetFaceModelVertices(long userId, ref Vector3[] avVertices)
	{
		for (int i = 0; i < this.bodyCount; i++)
		{
			if(hdFaceFrameSources != null && hdFaceFrameSources[i] != null && (hdFaceFrameSources[i].TrackingId == (ulong)userId || userId == 0))
			{
				if(hdFaceModels != null && hdFaceModels[i] != null)
				{
					var vertices = hdFaceModels[i].CalculateVerticesForAlignment(hdFaceAlignments[i]);
					int verticesCount = vertices.Count;

					if(avVertices.Length == verticesCount)
					{
						for(int v = 0; v < verticesCount; v++)
						{
							avVertices[v].x = vertices[v].X;
							avVertices[v].y = vertices[v].Y;
							avVertices[v].z = vertices[v].Z;  // -vertices[v].Z;
						}
					}

					return true;
				}
			}
		}
		
		return false;
	}
	
	public int GetFaceModelTrianglesCount()
	{
		var triangleIndices = FaceModel.TriangleIndices;
		int triangleLength = triangleIndices.Count;

		return triangleLength;
	}
	
	public bool GetFaceModelTriangles(bool bMirrored, ref int[] avTriangles)
	{
		var triangleIndices = FaceModel.TriangleIndices;
		int triangleLength = triangleIndices.Count;

		if(avTriangles.Length >= triangleLength)
		{
			for(int i = 0; i < triangleLength; i += 3)
			{
				//avTriangles[i] = (int)triangleIndices[i];
				avTriangles[i] = (int)triangleIndices[i + 2];
				avTriangles[i + 1] = (int)triangleIndices[i + 1];
				avTriangles[i + 2] = (int)triangleIndices[i];
			}

			if(bMirrored)
			{
				Array.Reverse(avTriangles);
			}

			return true;
		}

		return false;
	}
	
}
