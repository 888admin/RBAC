<template>
  <div>
    <el-form style="width: 0%;margin-bottom: 2px;">
      <el-button @click="add">添加</el-button>
    </el-form>
    <el-table :data="tableData" style="width: 100%;margin-bottom: 20px;" row-key="MenuId" border default-expand-all :tree-props="{children: 'children', hasChildren: 'hasChildren'}">
      <el-table-column prop="MenuId" label="菜单Id" sortable width="180">
      </el-table-column>
      <el-table-column prop="MenuName" label="菜单名称" sortable width="180">
      </el-table-column>
      <el-table-column prop="MenuLink" label="菜单链接" width="180">
      </el-table-column>
      <el-table-column>
        <template slot-scope="scope">
          <el-button size="mini" @click="handleEdit(scope.row.MenuId)">修改</el-button>
          <el-button size="mini" type="danger" @click="handleDelete(scope.row.MenuId)">删除</el-button>
        </template>
      </el-table-column>
    </el-table>
    <el-dialog title="新增" :visible.sync="dialogTableVisible">
      <meun-create @routertable="routertable"></meun-create>
    </el-dialog>
    <el-dialog title="编辑" :visible.sync="dialogTableVisibleUpd">
      <menu-upd @updtable="updtable" :MenuId=editid></menu-upd>
    </el-dialog>
  </div>
</template>
<script>
import MenuUpd from '@/views/MenuUpd.vue'
import MeunCreate from '@/views/MenuCreate.vue';
export default {
  components: {
    MeunCreate,
    MenuUpd
  },
  data () {
    return {
      editid: 0,
      tableData: [],
      dialogTableVisible: false,
      dialogTableVisibleUpd: false,
    }
  },
  methods: {
    Show () {
      this.$http.get("/api/Menu/QueryAll").then(res => {
        this.tableData = res.data;
      })
    },
    handleEdit (id) {
      this.editid = id;
      this.dialogTableVisibleUpd = true;
    },
    handleDelete (id) {
      this.$confirm('此操作将永久删除该文件, 是否继续?', '提示', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'warning'
      }).then(() => {
        this.$http.get("/api/Menu/DelMenu?id=" + id).then(res => {
          if (res.data == 500) {
            this.$message.error("不能删除");
          }
          else if (res.data > 0) {
            this.$message({
              type: 'success',
              message: '删除成功!'
            });
            this.$router.push('/Menulist')
          }
          else {
            this.$message.error("删除失败");
          }
        })
      }).catch(() => {
        this.$message({
          type: 'info',
          message: '已取消删除'
        });
      });
    },

    add () {
      this.dialogTableVisible = true;
    },
    routertable (val) {
      this.dialogTableVisible = !val;
      this.Show();
    },
    updtable (val) {

    }

  },
  created () {
    this.Show();
  }
}
</script>
