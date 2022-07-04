<template>
  <div>
    <el-table :data="tableData" style="width: 100%">
      <el-table-column prop="RoleId" label="管理员ID" width="180">
      </el-table-column>
      <el-table-column prop="RoleName" label="身份" width="180">
      </el-table-column>
      <el-table-column prop="CreateTime" label="任职时间" width="180">
        <template slot-scope="scope">
          {{scope.row.CreateTime.substr(0,10)}}
        </template>
      </el-table-column>
      <el-table-column prop="IsDelete" label="状态" width="180">
        <template slot-scope="scope">
          <span v-if='scope.row.IsDelete==1'>已授权</span>
          <span v-if='scope.row.IsDelete==0'>未授权</span>
        </template>
      </el-table-column>
      <el-table-column label="操作">
        <template slot-scope="scope">
          <el-button size="mini" @click="handleEdit(scope.$index, scope.row)">编辑</el-button>
          <el-button size="mini" @click="authorization(scope.row.roleId)">权限授权</el-button>
          <el-button size="mini" type="danger" @click="handleDelete(scope.$index, scope.row)">删除</el-button>
        </template>
      </el-table-column>
    </el-table>
    <el-dialog title="分配权限" :visible.sync="dialogVisible">
      <role-tree></role-tree>
      <span slot="footer" class="dialog-footer">
        <el-button @click="dialogVisible = false">取 消</el-button>
        <el-button type="primary" @click="SavePermission()">确 定</el-button>
      </span>
    </el-dialog>
  </div>
</template>


<script>
import roleTree from './roleTree.vue';
export default {
  components: { roleTree },
  data () {
    return {
      tableData: [],
      dialogVisible: false,
      RoleId: 0
    }
  },
  methods: {
    handleEdit (index, row) {
      console.log(index, row);
    },
    handleDelete (index, row) {
      console.log(index, row);
    },
    formatter (row, column, cellValue, index) {
      return row.isLock ? "是" : "否";
    },
    authorization (RoleId) {
      this.RoleId = RoleId;
      this.dialogVisible = true;
    },
    Show () {
      this.$http.get('/api/Role/RoleShow').then(res => {
        this.tableData = res.data
      })
    },
    SavePermission () {
      var checkedId = this.$refs.dialogTree.$refs.roleTree.getCheckedNodes(true, true).map(t => t.value);
      var RoleId = this.RoleId;
      this.$http.post('/api/Role/SavePermission', { MenuId: checkedId, RoleId: RoleId }).then(res => {

      });
      this.dialogVisible = false;
    }
  },
  created: function () {
    this.Show()
  }
}
</script>