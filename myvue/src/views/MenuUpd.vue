<template>
  <div>
    <el-form ref="form" :model="form" label-width="80px">
      <el-cascader v-model="form.menuId" :options="options" :props="{ checkStrictly: true }" ref="GetMeId" clearable></el-cascader>
      <el-form-item label="菜单名称">
        <el-input v-model="form.menuName"></el-input>
      </el-form-item>
      <el-form-item label="菜单链接">
        <el-input v-model="form.menuLink"></el-input>
      </el-form-item>
      <el-form-item>
        <el-button type="primary" @click="onSubmit">修改</el-button>
        <el-button>取消</el-button>
      </el-form-item>
    </el-form>
  </div>
</template>
<script>
import { Breadcrumb, FormItem } from 'element-ui';
export default {
  props: ['menuId'],
  data () {
    return {
      form: {
        menuId: this.menuId,
        pId: null,
        menuName: '',
        menuLink: '',
      },
      value: [],
      options: []
    }
  },
  methods: {
    onSubmit () {
      this.form.pId = this.$refs["GetMeId"].checkedValue[this.$refs["GetMeId"].checkedValue.length - 1];
      this.form.pId = this.value.slice(-1)[0];
      console.log(this.form);
      this.$http.post("/api/Menu/AddMenu", this.form).then(res => {
        if (res.data > 0) {
          this.$message.success("添加成功");
          this.$emit("routertable", true);
        }
      })
    },
    FanT () {

      var id = this.form.menuId;
      debugger
      this.$http.get("/api/Menu/GetBity?id=" + id).then(res => {
        debugger
        this.form = res.data;
      })
    },
    Menu () {
      this.form = [];
      this.$http.get("/api/Menu/QueryCreateMeun").then(res => {
        var reg = new RegExp('\\,"children":\\[]', 'g');

        this.options = JSON.parse(JSON.stringify(res.data).replace(reg, ''));
        console.log(res)
      })
    }
  },
  created () {
    this.Menu();
    this.FanT();
  },
}
</script>