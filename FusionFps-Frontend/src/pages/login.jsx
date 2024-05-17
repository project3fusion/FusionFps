import { Fragment } from "react";
import GlobalStyles from "assets/styles/GlobalStyles"
import Layout from "components/layout";

import Header from "sections/Header/v2";
import Login from "sections/AuthPages/Login";

export default function LoginPage() {
  return (
    <Fragment>
      <Layout>
        <GlobalStyles />

        <Header />
        <Login />
      </Layout>
    </Fragment>
  );
}
