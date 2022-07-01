<template>
  <div>
    <el-table :data="tableData" style="width: 100%">
      <el-table-column prop="AdminId" label="用户ID" width="180">
      </el-table-column>
      <el-table-column prop="UserName" label="用户名" width="180">
      </el-table-column>
      <el-table-column prop="Email" label="邮箱" width="180">
      </el-table-column>
      <el-table-column prop="CreateTime" label="时间" width="180">
      </el-table-column>
      <el-table-column label="操作">
        <template slot-scope="scope">
          <el-button size="mini" @click="handleEdit(scope.$index, scope.row)">编辑</el-button>
          <el-button size="mini" type="danger" @click="handleDelete(scope.$index, scope.row)">删除</el-button>
        </template>
      </el-table-column>
    </el-table>
    <el-pagination @size-change="handleSizeChange" @current-change="handleCurrentChange" :current-page="form.Pageindex" :page-sizes="[1, 2, 3, 4]" :page-size="form.Pagesize" layout="total, sizes, prev, pager, next, jumper" :total="form.Totalcount">
    </el-pagination>
  </div>
</template>

<script>
export default {
  data () {
    return {
      tableData: [],
      form: {
        Pageindex: 1,
        Pagesize: 2,
        Totalcount: 0
      }
    }
  },
  methods: {
    handleSizeChange (val) {
      this.form.Pageindex = 1
      this.form.Pagesize = val
      this.Show()
    },
    handleCurrentChange (val) {
      this.form.Pageindex = 1
      this.form.Pageindex = val
      this.Show()
    },
    Show () {
      this.$http.get("/api/Admin/AdminShow", { params: this.form }).then(res => {
        this.tableData = res.data.Item1
        this.form.Totalcount = res.data.Item2
      })
    },
    handleEdit (index, row) {
      console.log(index, row);
    },
    handleDelete (index, row) {
      console.log(index, row);
    }
  },
  created: function () {
    this.Show()
  }
}
</script>