## detect and display an image from all cameras

from imutils.video import VideoStream
import cv2
import imutils

videoSrc = [None] * 20
frame = [None] * 20
name = [None] * 20
for i in range(20):
	try:
		videoSrc[i] = VideoStream(src=i).start
	except:
		break:
for i in range(len(videoSrc)):
	name[i] = "Camera" + str(i)
while True:
	for i in range(len(videoSrc)):
		frame[i] = videoSrc[i].read()
		frame[i] = imutils.resize(frame, width=600)
	for i in range(len(videoSrc)):
		cv2.imshow(name[i], frame)
	if cv2.waitKey(1) & 0xFF == ord('q'):
		break
cv2.destroyAllWindows()