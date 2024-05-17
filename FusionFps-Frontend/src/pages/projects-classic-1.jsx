import { Fragment } from "react";
import GlobalStyles from "assets/styles/GlobalStyles"
import Layout from "components/layout";

import Header from "sections/Header/v2";
import ProjectClassic from "sections/ProjectPages/ProjectClassic/v1";
import Footer from "sections/Footer/v1";

export default function ProjectClassicOne() {
  return (
    <Fragment>
      <Layout>
        <GlobalStyles />
        <Header />
        <ProjectClassic />
        <Footer />
      </Layout>
    </Fragment>
  );
}
