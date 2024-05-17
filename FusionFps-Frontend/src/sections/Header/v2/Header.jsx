import { useState } from "react";
import { MdNotes, MdOutlineKeyboardArrowDown, MdOutlineKeyboardArrowRight } from "react-icons/md";
import NavWrapper from "./Header.style";
import Button from "components/button";
import MobileMenu from "../MobileMenu/MobileMenu";


import data from "assets/data/menu/menuData";
import logo from "assets/images/logo.png";
import connectIcon from "assets/images/icons/connect.png";



const Header = () => {
  const [isMobileMenu, setMobileMenu] = useState(false);


  const handleMobileMenu = () => {
    setMobileMenu(!isMobileMenu);
  };

 



  return (
    <NavWrapper className="gamfi_header" id="navbar">
      <div className="container">
        <div className="gamfi_menu_sect">
          <div className="gamfi_menu_left_sect">
            <div className="logo">
              <a href="/">
                <img src={logo} alt="gamfi nft logo" />
              </a>
            </div>
          </div>
          <div className="gamfi_menu_right_sect gamfi_v1_menu_right_sect">
            <div className="gamfi_menu_list">
              <ul>
                {data?.map((menu, i) => (
                  <li key={i}>
                    <a href={menu.url}>{menu.title} {menu.subMenus?.length > 0 && <MdOutlineKeyboardArrowDown />}</a>
                    {menu.subMenus?.length > 0 && (
                      <ul className="sub_menu_list">
                        {menu.subMenus?.map((subMenu, i) => (
                          <li key={i}>
                            <a href={subMenu.url}>{subMenu.title} {subMenu?.subMenuChilds?.length > 0 && <MdOutlineKeyboardArrowRight />}</a>
                            {subMenu?.subMenuChilds?.length > 0 && (
                              <ul className="sub_menu_child_list">
                                {subMenu?.subMenuChilds?.map((subChild, i) => (
                                  <li key={i}>
                                    <a href={subChild.url}> {subChild.title} </a>
                                  </li>
                                ))}
                              </ul>
                            )}
                          </li>
                        ))}
                      </ul>
                    )}
                  </li>
                ))}
              </ul>
            </div>
            <div className="gamfi_menu_btns">
              <button className="menu_btn" onClick={handleMobileMenu}>
                <MdNotes />
              </button>
              
              <Button
                href="#"
                sm
                variant="white"
                className="connect_btn"
                
              >
                
                Launch App
              </Button>
            </div>
          </div>
        </div>
        {isMobileMenu && <MobileMenu mobileMenuhandle={handleMobileMenu} />}
      </div>
    </NavWrapper>
  );
};

export default Header;

