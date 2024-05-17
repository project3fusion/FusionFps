import { Routes, Route } from "react-router-dom";
import HomeTwo from "pages/home-two";
import ProjectsClassic from "pages/projects-classic-1";
import ProjectsCalendar from "pages/projects-calendar";
import Signin from "pages/login";
import Signup from "pages/register";
import ForgetPassword from "pages/forget-password";
import Leaderboard from "pages/leaderboard";



function App() {
  return (
    <>
    <Routes>
      <Route path="/" element={<HomeTwo />} />
      <Route path="/weapon-inventory" element={<ProjectsClassic />} />
      <Route path="/gemrewards" element={<ProjectsCalendar />} />
      <Route path="/login" element={<Signin />} />
      <Route path="/register" element={<Signup />} />
      <Route path="/forget-password" element={<ForgetPassword />} />
      <Route path="/leaderboard" element={<Leaderboard />} />


    </Routes></>
  );
}

export default App;
