<template>
  <div>
    <el-tree ref="roleTree" :data="data" show-checkbox node-key="value" :default-expand-all="true" :props="defaultProps">
    </el-tree>
  </div>
</template>

<script>
export default {
  data () {
    return {
      data: [],
      defaultProps: {
        children: 'children',
        label: 'label'
      }
    };
  },
  props: {
    RoleId: {
      type: Number,
    },
  },
  methods: {
    getdata () {
      var list = this.$refs.roleTree.getCheckedNodes(true, true).map(m => m.value);
    }
  },
  created: function () {
    this.$http.get("/api/Menu/Show").then(res => {
      var reg = new RegExp('\\,"children":\\[]', 'g')
      this.data = JSON.parse(JSON.stringify(res.data).replace(reg, ''));
    });  
  },

}
</script>

<style>
</style>