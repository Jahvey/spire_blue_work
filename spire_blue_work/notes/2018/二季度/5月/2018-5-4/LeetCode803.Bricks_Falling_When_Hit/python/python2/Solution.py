class Solution(object):
    def hitBricks(self, grid, hits):
        """
        :type grid: List[List[int]]
        :type hits: List[List[int]]
        :rtype: List[int]
        """
        grid2 = [[[] for j in i] for i in grid]
        for i in range(len(grid)):
            for j in range(len(grid[0])):
                for i2, j2 in [(i - 1, j), (i + 1, j), (i, j - 1), (i, j + 1)]:
                    if not (i2 < 0 or i2 >= len(grid) or j2 < 0 or j2 >= len(grid[0])):
                        grid2[i][j].append((i2, j2))

        grid3 = [[[] for j in i] for i in grid]

        for j in range(len(grid[0])):
            queue = [(0, j)]
            seen = set(queue)
            while queue:
                i, j = queue.pop(0)
                seen.add((i, j))
                if grid[i][j] == 1:
                    for child in grid2[i][j]:
                        i2, j2 = child
                        if i2 == 0:
                            continue
                        if child not in seen and (i, j) not in grid3[i2][j2]:
                            queue.append(child)
                            grid3[child[0]][child[1]].append((i, j))

        ans = []
        for i, j in hits:
            grid[i][j] = 0
            queue = [(i, j)]
            seen = set(queue)
            res = 0
            while queue:
                i2, j2 = queue.pop(0)
                seen.add((i2, j2))
                for child in grid2[i2][j2]:
                    if child in seen: continue
                    if child[0] == 0: continue
                    i3, j3 = child
                    if grid[i3][j3] == 0: continue
                    if (i2, j2) in grid3[i3][j3]:
                        grid3[child[0]][child[1]].remove((i2, j2))

                    x, y = i3, j3
                    while len(grid3[x][y]) == 1:
                        i4, j4 = grid3[x][y][0]
                        if (x, y) in grid3[i4][j4]:
                            grid3[i4][j4].remove((x, y))
                            if len(grid3[i4][j4]) == 1:
                                x, y = i4, j4
                            else:
                                break
                        else:
                            break

                    if not grid3[child[0]][child[1]]:
                        grid[i3][j3] = 0
                        queue.append((i3, j3))
                        res += 1
            ans.append(res)
        return ans