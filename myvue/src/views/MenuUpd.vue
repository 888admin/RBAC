<template>
  <div>
    <el-form ref="form" :model="form" label-width="80px">
      <el-cascader v-model="value" :options="options" :props="{ checkStrictly: true }" ref="GetMeId" clearable></el-cascader>
      <el-form-item label="菜单名称">
        <el-input v-model="form.MenuName"></el-input>
      </el-form-item>
      <el-form-item label="菜单链接">
        <el-input v-model="form.MenuLink"></el-input>
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
  props: ['MenuId'],
  data () {
    return {
      form: {
        MenuId: this.GetMeId,
        PId: null,
        MenuName: '',
        MenuLink: '',
      },
      value: [],
      options: []
    }
  },
  methods: {
    onSubmit () {
      this.form.MenuId = this.$refs["GetMeId"].checkedValue[this.$refs["GetMeId"].checkedValue.length - 1];
      this.$http.post("/api/Menu/AddMenu", this.form).then(res => {
        if (res.data > 0) {
          this.$message.success("修改成功");
          this.$emit("routertable", true);
        }
      })
    },
    FanT () {

      var id = this.form.MenuId;
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