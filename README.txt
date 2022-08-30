
Small World

  Given a list of points in the plane, write a program that outputs each point along with the three other points that are closest to it.
  These three points should be ordered by distance.
 
  For example, given a set of points where each line is of the form: ID x-coordinate y-coordinate

    1  0.0      0.0
    2  10.1     -10.1
    3  -12.2    12.2
    4  38.3     38.3
    5  79.99    179.99


  Your program should output:

    1 2,3,4
    2 1,3,4
    3 1,2,4
    4 1,2,3
    5 4,3,1 