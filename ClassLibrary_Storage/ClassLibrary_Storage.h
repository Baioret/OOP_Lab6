#pragma once
#include <stdio.h>
#include <string>
using namespace System;

namespace ClassLibraryStorage {

	public ref class CShape
	{
	protected:
		int x, y;
		int delta = 5;
		bool selected = true;
		String^ color = "LightGoldenrodYellow";

	public:

		 virtual ~CShape() {}

		 virtual void Select() {
			 selected = true;
		 }

		 virtual void Unselect() {
			 selected = false;
		 }

		 virtual bool Selected()
		 {
			 if (selected)
				 return true;
			 else
				 return false;
		 }

		 virtual void Draw() = 0;

		 virtual bool WasClicked(int x0, int y0) = 0;

		 virtual void ChangeSize(String^ mode) = 0;

		 virtual void ChangeColor(String^ color) {

			 this->color = color;
		 }

		 virtual void Move(String^ direction) {

			 if (!Movable(direction))
				 return;

			 if (direction == "up")
				 y = y - delta;
			 else if (direction == "down")
				 y = y + delta;
			 else if (direction == "right")
				 x = x + delta;
			 else if (direction == "left")
				 x = x - delta;

			 UpdateExtremePoints();
		 }

		 virtual bool Movable(String^ direction) = 0; // перекрыт в основном проекте, потому что нужен класс DrawFigures

		 virtual void UpdateExtremePoints() = 0;
	};

	public ref class IList
	{
	public:
		virtual void add(CShape^ obj) = 0;
		virtual void del(CShape^ obj) = 0;
		virtual CShape^ getObject() = 0;
		virtual void first() = 0;
		virtual void next() = 0;
		virtual bool isEOL() = 0;
	};

	public ref class MyStorage : public IList {

	protected:

		array<CShape^>^ data;
		int curr, size, count;

		void resize() {

			size++;

			array<CShape^>^ tmp = gcnew array<CShape^>(size);

			for (int i = 0; i < size - 1; i++)
				tmp[i] = data[i];

			data = tmp;
		}

	public:

		MyStorage() {
			curr = 0; size = 0; count = 0;
			data = gcnew array<CShape^>(size);
		}

		void add(CShape^ obj) override {

			if (this->isEOL())
			{
				if (count < curr) {
					for (int i = 0; i < size; i++)
						if (data[i] == nullptr) {
							data[i] = obj;
							count++;
							return;
						}
				}

				this->resize();
			}

			while (data[curr] != nullptr) {
				curr++;
				if (this->isEOL())
					this->resize();
			}

			data[curr] = obj;
			curr++;
			count++;
		}

		void del(CShape^ obj) override {
			delete obj;
			data[curr] = nullptr;
			count--;
		}

		CShape^ getObject() override {
			return data[curr];
		}

		void first() override {
			curr = 0;
		}

		void next() override {
			curr++;
		}

		bool isEOL() override {
			return curr > size - 1;
		}
	};

}
