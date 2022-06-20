# Connected Cells in a Grid

Consider a matrix where each cell contains either a 0 or a 1. Any cell containing a 1 is called a filled cell. Two cells  are said to be connected if they are adjacent to each other horizontally, vertically, or diagonally. In the following  grid, all cells marked x are connected to the cell marked Y.

XXX
XYX 
XXX


If one or more filled cells are also connected, they form a region. Note that each cell in a region is connected to  zero or more cells in the region but is not necessarily directly connected to all the other cells in the region.Given an n x in matrix, find and print the number of cells in the largest region in the matrix. Note that there may be more than one region in the matrix.For example, there are two regions in the following 3 x 3 matrix. The larger region at the top left contains 3 cells.The smaller one at the bottom right contains 1.

110 
100 
001


Function Description
Complete the connectedCell function in the editor below.
connectedCell has the following parameter(s):
- int matrixtraml: matrix[i] represents the it'" row of the matrix


Returns
- int: the area of the largest region
