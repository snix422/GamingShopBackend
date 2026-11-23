import Avatar from "@mui/material/Avatar";
import Divider from "@mui/material/Divider";
import React from "react";

interface CommentItemProps {
  data: any;
}

const CommentItem: React.FC<CommentItemProps> = ({ data }) => {
  return (
    <div className="w-[40vw] max-lg:w-[60vw] max-sm:w-[80vw] flex flex-col gap-4 rounded-md shadow-lg p-2">
      <div className="flex items-center gap-4 pl-4">
        <Avatar>{data.author.at(0)}</Avatar>
        <span>{data.author}</span>
      </div>
      <Divider />
      <p className="pl-4">{data.review}</p>
    </div>
  );
};

export default CommentItem;
