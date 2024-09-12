How to Run this code.

1. Open this code into two instances of Visual studio.
2. Set startup Project Demo in instance 1 and start it. Put a debug point as mentioned in the below snap.  DO NOT MOVE CODE UNTILL STEPS 5 REACHED . THERE IS INFO WHEN TO MOVE FORWARD. 
   ![image](https://github.com/user-attachments/assets/791c29da-bfe3-4f7d-96f8-17e1ca926ce6)
3. In the second intance of visual studio set DemoHub.Client as a startup project. Put a breakpont as mentioned in the below snap.
    ![image](https://github.com/user-attachments/assets/ac502838-1327-452b-8c68-940ce9e28524)

5. Run Client as well and you get a connectionId in the console. 
6. Since there is a bearKpoint set in step 2 in server code. So the server code will be bloked and after 30 seconds client will try to reconnect.
7. Now Press F5 in server app.
8. Now Press F5 in the Client code.

OUTPUT: New connection Id recived for Client. 
