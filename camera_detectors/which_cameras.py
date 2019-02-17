## detect and display an image from all cameras

from imutils.video import VideoStream
import cv2
import imutils

videoSrc = [None] * 20
frame = [None] * 20
name = [None] * 20
i = 0
for i in range(20):
	try:
		videoSrc[i] = VideoStream(src=int(i)).start()
		i=+1
	except:
		break
for j in range(i):
	name[i] = "Camera " + str(i)
while True:
	for j in range(i + 1):
		frame[j] = videoSrc[j].read()
		frame[j] = imutils.resize(frame[j], width=600)
	for j in range(i + 1):
		cv2.imshow(name[j], frame[j])
	if cv2.waitKey(1) & 0xFF == ord('q'):
		break
cv2.destroyAllWindows()