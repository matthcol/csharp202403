# verify c# programe with python and numpy

import numpy as np

nMax = 1_000_000
data = np.arange(1, nMax + 1, dtype = np.uint64)

n = 4
chunk = nMax // n
total = np.uint64(0)
for i in range(n):
    iMin = i*chunk
    iMax = (i+1)*chunk
    partSum = data[iMin:iMax].sum()
    total += partSum
    print(f"partial sum data[{iMin:>7}, {iMax:>7}] = {partSum:>13}") 
print("Total:", total)
assert total == data.sum()