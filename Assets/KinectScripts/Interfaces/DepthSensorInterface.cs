using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface DepthSensorInterface
{
	// initializes libraries and resources needed by this sensor interface
	// returns true if the resources are successfully initialized, false otherwise
	bool InitSensorInterface(ref bool bNeedRestart);

	// releases the resources and libraries used by this interface
	void FreeSensorInterface();

	// returns the number of available sensors, controllable by this interface
	// if the number of sensors is 0, FreeSensorInterface() is invoked and the interface is not used any more
	int GetSensorsCount();

	// opens the default sensor and inits needed resources. returns new sensor-data object
	KinectInterop.SensorData OpenDefaultSensor(KinectInterop.FrameSource dwFlags, float sensorAngle, bool bUseMultiSource);

	// closes the sensor and frees used resources
	void CloseSensor(KinectInterop.SensorData sensorData);

	// this method is invoked periodically to update sensor data, if needed
	// returns true if update is successful, false otherwise
	bool UpdateSensorData(KinectInterop.SensorData sensorData);


	// gets next multi source frame, if one is available
	// returns true if there is a new multi-source frame, false otherwise
	bool GetMultiSourceFrame(KinectInterop.SensorData sensorData);

	// frees the resources taken by the last multi-source frame
	void FreeMultiSourceFrame(KinectInterop.SensorData sensorData);

	// polls for new body/skeleton frame. must fill in all needed body and joints' elements (tracking state and position)
	// returns true if new body frame is available, false otherwise
	bool PollBodyFrame(KinectInterop.SensorData sensorData, ref KinectInterop.BodyFrameData bodyFrame, ref Matrix4x4 kinectToWorld);

	// polls for new color frame data
	// returns true if new color frame is available, false otherwise
	bool PollColorFrame(KinectInterop.SensorData sensorData);

	// polls for new depth and body index frame data
	// returns true if new depth or body index frame is available, false otherwise
	bool PollDepthFrame(KinectInterop.SensorData sensorData);

	// polls for new infrared frame data
	// returns true if new infrared frame is available, false otherwise
	bool PollInfraredFrame(KinectInterop.SensorData sensorData);

	// performs sensor-specific fixes of joint positions and orientations
	void FixJointOrientations(KinectInterop.SensorData sensorData, ref KinectInterop.BodyData bodyData);

	// returns depth frame coordinates for the given 3d space point
	Vector2 MapSpacePointToDepthCoords(KinectInterop.SensorData sensorData, Vector3 spacePos);

	// returns 3d Kinect-space coordinates for the given depth frame point
	Vector3 MapDepthPointToSpaceCoords(KinectInterop.SensorData sensorData, Vector2 depthPos, ushort depthVal);

	// returns color-space coordinates for the given depth point
	Vector2 MapDepthPointToColorCoords(KinectInterop.SensorData sensorData, Vector2 depthPos, ushort depthVal);

	// estimates all color-space coordinates for the current depth frame
	// returns true on success, false otherwise
	bool MapDepthFrameToColorCoords(KinectInterop.SensorData sensorData, ref Vector2[] vColorCoords);


	// returns the index of the given joint in joint's array
	int GetJointIndex(KinectInterop.JointType joint);
	
	// returns the joint at given index
	KinectInterop.JointType GetJointAtIndex(int index);
	
	// returns the parent joint of the given joint
	KinectInterop.JointType GetParentJoint(KinectInterop.JointType joint);
	
	// returns the next joint in the hierarchy, as to the given joint
	KinectInterop.JointType GetNextJoint(KinectInterop.JointType joint);

	// returns true if the face tracking is supported by this interface, false otherwise
	bool IsFaceTrackingAvailable(ref bool bNeedRestart);

	// initializes libraries and resources needed by face tracking subsystem
	bool InitFaceTracking(bool bUseFaceModel, bool bDrawFaceRect);

	// releases the resources and libraries used by face tracking subsystem
	void FinishFaceTracking();

	// this method is invoked periodically to update the face tracking data
	// returns true if update is successful, false otherwise
	bool UpdateFaceTracking();

	// returns true if face tracking is initialized, false otherwise
	bool IsFaceTrackingInitialized();

	// returns true if face rectangle(s) must be drawn in color map, false otherwise
	bool IsDrawFaceRect();

	// returns true if the face of the specified user is being tracked at the moment, false otherwise
	bool IsFaceTracked(long userId);

	// gets the face rectangle in color coordinates. returns true on success, false otherwise
	bool GetFaceRect(long userId, ref Rect faceRect);

	// visualizes face tracker debug information
	void VisualizeFaceTrackerOnColorTex(Texture2D texColor);

	// gets the head position of the specified user. returns true on success, false otherwise
	bool GetHeadPosition(long userId, ref Vector3 headPos);
	
	// gets the head rotation of the specified user. returns true on success, false otherwise
	bool GetHeadRotation(long userId, ref Quaternion headRot);

	// gets the AU values for the specified user. returns true on success, false otherwise
	bool GetAnimUnits(long userId, ref Dictionary<KinectInterop.FaceShapeAnimations, float> afAU);

	// gets the SU values for the specified user. returns true on success, false otherwise
	bool GetShapeUnits(long userId, ref Dictionary<KinectInterop.FaceShapeDeformations, float> afSU);

	// returns the length of model's vertices array for the specified user
	int GetFaceModelVerticesCount(long userId);

	// gets the model vertices for the specified user. returns true on success, false otherwise
	bool GetFaceModelVertices(long userId, ref Vector3[] avVertices);
	
	// returns the length of model's triangles array
	int GetFaceModelTrianglesCount();
	
	// gets the model triangle indices. returns true on success, false otherwise
	bool GetFaceModelTriangles(bool bMirrored, ref int[] avTriangles);
	

}
