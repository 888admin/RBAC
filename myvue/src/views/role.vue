<template>
  <div>
    <el-table :data="tableData" style="width: 100%">
      <el-table-column prop="RoleId" label="角色Id" width="180">
      </el-table-column>
      <el-table-column prop="RoleName" label="角色名称" width="180">
      </el-table-column>
      <el-table-column label="操作">
        <template slot-scope="scope">
          <el-button size="mini" @click="handleEdit(scope.$index, scope.row)">编辑</el-button>
          <el-button size="mini" @click="assignPerm(scope.row.RoleId)">分配权限</el-button>
          <el-button size="mini" type="danger" @click="handleDelete(scope.$index, scope.row)">删除
          </el-button>
        </template>
      </el-table-column>
    </el-table>
    <el-dialog title="分配权限" :visible.sync="dialogVisible">
      <menu-tree ref="dialogTree" :RoleId="RoleId"></menu-tree>
      <span slot="footer" class="dialog-footer">
        <el-button @click="dialogVisible = false">取 消</el-button>
        <el-button type="primary" @click="SavePermission()">确 定</el-button>
      </span>
    </el-dialog>
  </div>
</template>

<script>

import menuTree from './menuTree';
export default {
  components: {
    menuTree
  },
  data () {
    return {
      tableData: [],
      moment,
      dialogVisible: false,
      RoleId: 0,
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
    assignPerm (RoleId) {
      this.RoleId = RoleId;
      this.dialogVisible = true;
    },
    SavePermission () {
      var checkedId = this.$refs.dialogTree.$refs.menuTree.getCheckedNodes(true, true).map(m => m.value);
      var RoleId = this.RoleId;
      this.$http.post('/api/Role/SavePermission', { MenuId: checkedId, RoleId: RoleId }).then(m => {

      });
      this.dialogVisible = false;
    },
    show () {
      this.$http.get('api/Role/GetBity').then(m => {
        this.tableData = m.data;
      });
    }
  },
  created () {
    this.show()
  },
}
</script>