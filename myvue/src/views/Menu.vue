<template>
  <div>
    <el-container>
      <el-header>权限管理系统</el-header>
      <el-container>
        <el-aside width="200px">
          <el-menu default-active="/Menulist" :router="true" class="el-menu-vertical-demo" :unique-opened="false" @open="handleOpen" @close="handleClose" background-color="#545c64" text-color="#fff" active-text-color="#ffd04b">
            <el-submenu :index="String(item.MenuId)" v-for="(item, index) in lists" :key="item.MenuId">
              <template slot="title">
                <i class="el-icon-location"></i>
                <span>{{item.MenuName}}</span>
              </template>
              <template v-for="(submenu, i) in list.filter(m => m.PId == item.MenuId)">
                <el-menu-item :index="items.MenuLink" v-for="(items, subIndex) in list.filter(m =>m.PId == submenu.MenuId)" :key="items.MenuId">
                  <span>{{items.MenuName}}</span>
                </el-menu-item>
              </template>
            </el-submenu>
          </el-menu>
        </el-aside>
        <el-main>
          <router-view />
        </el-main>
      </el-container>
    </el-container>
  </div>
</template>

<script>
export default {
  data () {
    return {
      list: []
    }
  },
  methods: {
    handleOpen (key, keyPath) {
      console.log(key, keyPath);
    },
    handleClose (key, keyPath) {
      console.log(key, keyPath);
    },
    show () {
      this.$http.get('/api/Menu/Show').then(res => {
        this.list = res.data
      })
    },
  },
  created: function () {
    this.show()
  },
  computed: {
    lists () {
      return this.list.filter((v, i, arr) => {
        return v.PId == 0
      })
    }
  },

}
</script>

<style>
.el-header,
.el-footer {
  background-color: #b3c0d1;
  color: #333;
  text-align: center;
  line-height: 60px;
}

.el-aside {
  background-color: #545c64;
  color: #333;
  text-align: center;
  line-height: 200px;
}

.el-main {
  background-color: #e9eef3;
  color: #333;
  text-align: center;
  line-height: 40px;
  height: calc(100vh - 100px);
}

body > .el-container {
  margin-bottom: 40px;
}

.el-container:nth-child(5) .el-aside,
.el-container:nth-child(6) .el-aside {
  line-height: 260px;
}

.el-container:nth-child(7) .el-aside {
  line-height: 320px;
}
</style>