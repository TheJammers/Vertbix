namespace HyperCasual.Graphics.Utilities
{
    /// <summary>
    /// Responsible for generating the index list of a cylinder mesh.
    /// </summary>
    public static class GenerateCylinderIndexes
    {
        public static int[] Perform(int triangle_count)
        {
            var circle_triangle_index_count = (triangle_count*3)*2;
            var side_triangle_index_count = triangle_count*6;
            var total_indexes = circle_triangle_index_count + side_triangle_index_count;
            var indexes = new int[total_indexes];

            for (var triangle_index = 0; triangle_index < triangle_count; ++triangle_index)
            {
                var index = triangle_index*3;
                indexes[index] = 0;
                indexes[index + 1] = triangle_index + 1;
                indexes[index + 2] = triangle_index + 2 > triangle_count ? 1 : triangle_index + 2;
            }

            var max_vertex_index = (triangle_count*2) + 1;
            var triangle_offset = triangle_count*3;
            var vertex_offset = triangle_count + 1;
            for (var triangle = 0; triangle < triangle_count; ++triangle)
            {
                var index_offset = triangle*3;
                var index = index_offset + triangle_offset;
                var vertex_index = triangle + vertex_offset;

                indexes[index] = vertex_offset;
                indexes[index + 1] = vertex_index + 2 > max_vertex_index ? vertex_offset + 1 : vertex_index + 2;
                indexes[index + 2] = vertex_index + 1;
            }

            vertex_offset += 1;
            var index_start = triangle_count*6;
            for (var i = 0; i < triangle_count; ++i)
            {
                var index = i*6 + index_start;

                var bottom_left = vertex_offset + i;
                var bottom_right = bottom_left - 1 < vertex_offset
                    ? vertex_offset + triangle_count - 1
                    : bottom_left - 1;
                var top_left = bottom_left - vertex_offset + 1;
                var top_right = bottom_right - vertex_offset + 1;

                indexes[index + 0] = bottom_left;
                indexes[index + 1] = top_left;
                indexes[index + 2] = top_right;

                indexes[index + 3] = bottom_left;
                indexes[index + 4] = top_right;
                indexes[index + 5] = bottom_right;
            }

            return indexes;
        }
    }
}